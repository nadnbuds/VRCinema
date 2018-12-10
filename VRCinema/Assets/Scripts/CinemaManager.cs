using System.IO;
using UnityEngine;
using YoutubeExtractor;
using UnityEngine.Video;
using VideoLibrary;
using System.Threading;
using System.Threading.Tasks;
using System.ComponentModel;

public class CinemaManager : MonoBehaviour
{
    private string MainPath;

    [SerializeField]
    private SyncManager syncManager;

    [SerializeField]
    private VideoPlayer videoPlayer;

    private BackgroundWorker videoDownloader;

    private void Awake()
    {
        videoDownloader = new BackgroundWorker();
        MainPath = Application.persistentDataPath;
    }

    public void AddVideoToQueue(VideoData videoData)
    {
        syncManager.CmdAddVideoToQueue(videoData);

        videoDownloader.DoWork += (object o, DoWorkEventArgs e) => { DownloadVideo(videoData); };
        videoDownloader.RunWorkerCompleted += (object o, RunWorkerCompletedEventArgs e) => { syncManager.CmdDownloadFinished(); };
        videoDownloader.RunWorkerAsync();
    }

    public void PlayTopVideo()
    {
        VideoData video = syncManager.VideoQueue.Dequeue();
        videoPlayer.url = Path.Combine(MainPath, string.Join("", video.VideoTitle.Split(Path.GetInvalidFileNameChars())) + "." + VideoType.Mp4);
        videoPlayer.Play();
    }

    private void DownloadVideo(VideoData videoData)
    {
        YouTube youtube = YouTube.Default;
        Video video = youtube.GetVideo(videoData.VideoUrl);
        File.WriteAllBytes(Path.Combine(MainPath, string.Join("", videoData.VideoTitle.Split(Path.GetInvalidFileNameChars())) + "." + VideoType.Mp4), video.GetBytes());
    }
}