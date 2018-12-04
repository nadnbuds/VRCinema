using System.IO;
using UnityEngine;
using YoutubeExtractor;
using UnityEngine.Video;
using UnityEngine.Networking;
using System.Collections.Generic;

public class CinemaManager : MonoBehaviour
{
    [SerializeField]
    private VideoPlayer videoPlayer;

    [SyncVar]
    private Queue<VideoData> videoQueue;

    public void AddVideoToQueue(VideoData videoData)
    {
        videoQueue.Enqueue(videoData);
        DownloadVideo(videoData.VideoUrl);
    }

    public void PlayTopVideo()
    {
        VideoData video = videoQueue.Dequeue();
        videoPlayer.url = Path.Combine(Application.persistentDataPath, string.Join("", video.VideoTitle.Split(Path.GetInvalidFileNameChars())) + VideoType.Mp4);
        videoPlayer.Play();
    }

    private void DownloadVideo(string url)
    {
        IEnumerable<VideoInfo> videoInfos = DownloadUrlResolver.GetDownloadUrls(url);
        VideoInfo video = null;
        foreach(VideoInfo vid in videoInfos)
        {
            if(vid.VideoType == VideoType.Mp4)
            {
                video = vid;
                break;
            }
        }

        if (video.RequiresDecryption)
        {
            DownloadUrlResolver.DecryptDownloadUrl(video);
        }

        var videoDownloader = new VideoDownloader(video, Path.Combine(Application.persistentDataPath,string.Join("", video.Title.Split(Path.GetInvalidFileNameChars())) + video.VideoExtension));

        videoDownloader.DownloadFinished += (sender, args) =>
        {

        };

        StartCoroutine(videoDownloader.Execute());
    }
}