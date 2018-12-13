using System.IO;
using UnityEngine;
using YoutubeExtractor;
using UnityEngine.Video;
using VideoLibrary;
using System.ComponentModel;
using System.Collections.Generic;
using System.Collections;
using System.Threading;

public class CinemaManager : MonoBehaviour
{
    [SerializeField]
    private VideoPlayer videoPlayer;

    private BackgroundWorker videoDownloader;

    private Queue<VideoData> videoQueue;
    private Dictionary<VideoData, string> videoPaths;

    private void Awake()
    {
        videoDownloader = new BackgroundWorker();
        videoQueue = new Queue<VideoData>();
        videoPaths = new Dictionary<VideoData, string>();
    }

    public void AddVideoToQueue(VideoData videoData)
    {
        videoQueue.Enqueue(videoData);

        string filePath = Application.persistentDataPath + '/' + string.Join("", videoData.VideoTitle.Split(Path.GetInvalidFileNameChars())) + "." + VideoType.Mp4;
        videoPaths.Add(videoData, filePath);

        StartCoroutine(StartDownload(videoData, filePath));
    }

    private IEnumerator StartDownload(VideoData videoData, string path)
    {
        bool downloadFinished = false;
        if(File.Exists(path))
        {
            downloadFinished = true;
        }
        else
        {
            Thread thread = new Thread(() => { DownloadVideo(videoData, path); });
            thread.Start();
        }

        while(downloadFinished == false)
        {
            if (File.Exists(path))
            {
                downloadFinished = true;
            }

            yield return null;
        }

        SyncManager.instance.DownloadFinished(videoData);
    }

    private void DownloadVideo(VideoData videoData, string path)
    {
        YouTube youtube = YouTube.Default;
        Video video = youtube.GetVideo(videoData.VideoUrl);
        File.WriteAllBytes(path, video.GetBytes());
    }

    public void PlayTopVideo()
    {
        VideoData video = videoQueue.Dequeue();

        //@todo make this path set when VideoData is created
        videoPlayer.url = videoPaths[video];

        if(File.Exists(videoPlayer.url))
        {
            videoPlayer.Play();
        }
    }
}