using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Video;
using YoutubeExtractor;

public class CinemaManager : MonoBehaviour
{
    [SerializeField]
    private VideoPlayer videoPlayer;

    public void PlayVideo(string url)
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

        videoDownloader.DownloadProgressChanged += (sender, args) =>
        {
            Debug.Log(args.ProgressPercentage);
        };

        videoDownloader.DownloadFinished += (sender, args) =>
        {

            videoPlayer.url = Path.Combine(Application.persistentDataPath, string.Join("", video.Title.Split(Path.GetInvalidFileNameChars())) + video.VideoExtension);
            videoPlayer.Play();
        };

        videoDownloader.Execute();

    }
}
