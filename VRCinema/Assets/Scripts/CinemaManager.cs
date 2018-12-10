using System.IO;
using UnityEngine;
using YoutubeExtractor;
using UnityEngine.Video;
using VideoLibrary;
using System.ComponentModel;
using System.Collections.Generic;

public class CinemaManager : MonoBehaviour
{
    private string MainPath;

    [SerializeField]
    private VideoPlayer videoPlayer;

    private BackgroundWorker videoDownloader;

    private Queue<VideoData> videoQueue;

    private void Awake()
    {
        videoDownloader = new BackgroundWorker();
        videoQueue = new Queue<VideoData>();
        MainPath = Application.persistentDataPath;
    }

    public void AddVideoToQueue(VideoData videoData)
    {
        videoQueue.Enqueue(videoData);
        VideoData temp = new VideoData(videoData);

        videoDownloader.DoWork += (object o, DoWorkEventArgs e) => { DownloadVideo(videoData, Path.Combine(MainPath, string.Join("", videoData.VideoTitle.Split(Path.GetInvalidFileNameChars())) + "." + VideoType.Mp4)); };
        videoDownloader.RunWorkerCompleted += (object o, RunWorkerCompletedEventArgs e) => {  SyncManager.instance.DownloadFinished(temp); };
        videoDownloader.RunWorkerAsync();
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
        videoPlayer.url = Path.Combine(MainPath, string.Join("", video.VideoTitle.Split(Path.GetInvalidFileNameChars())) + "." + VideoType.Mp4);

        if(File.Exists(videoPlayer.url))
        {
            videoPlayer.Play();
        }
    }
}