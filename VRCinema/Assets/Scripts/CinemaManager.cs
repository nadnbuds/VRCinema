using System.IO;
using UnityEngine;
using YoutubeExtractor;
using UnityEngine.Video;
using VideoLibrary;
using System.Threading;
using System.Threading.Tasks;
using System.ComponentModel;
using UnityEngine.Networking;

public class CinemaManager : NetworkBehaviour
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
    }

    [ClientRpc]
    public void RpcPlayTopVideo()
    {
        VideoData video = syncManager.VideoQueue[0];

        //@todo make this path set when VideoData is created
        videoPlayer.url = Path.Combine(MainPath, string.Join("", video.VideoTitle.Split(Path.GetInvalidFileNameChars())) + "." + VideoType.Mp4);

        if(File.Exists(videoPlayer.url))
        {
            videoPlayer.Play();
        }
    }

    [ClientRpc]
    public void RpcStartVideoDownload(VideoData videoData)
    {
        videoData = syncManager.VideoQueue[syncManager.VideoQueue.Count - 1];

        videoDownloader.DoWork += (object o, DoWorkEventArgs e) => { DownloadVideo(videoData, Path.Combine(MainPath, string.Join("", videoData.VideoTitle.Split(Path.GetInvalidFileNameChars())) + "." + VideoType.Mp4)); };
        videoDownloader.RunWorkerCompleted += (object o, RunWorkerCompletedEventArgs e) => { syncManager.CmdDownloadFinished(); };
        videoDownloader.RunWorkerAsync();
    }

    private void DownloadVideo(VideoData videoData, string path)
    {
        YouTube youtube = YouTube.Default;
        Video video = youtube.GetVideo(videoData.VideoUrl);
        File.WriteAllBytes(path, video.GetBytes());
    }
}