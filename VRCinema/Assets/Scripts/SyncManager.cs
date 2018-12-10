using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using System.Collections.Generic;

public class VideoDataList : SyncListStruct<VideoData> { }

public class SyncManager : Singleton<SyncManager>
{
    [SerializeField]
    private CinemaManager cinemaManager;

    private Player localPlayer;

    private List<Player> players;
    private Dictionary<Player, Dictionary<string, bool>> downloadQueue;

    private void Awake()
    {
        players = new List<Player>();
        downloadQueue = new Dictionary<Player, Dictionary<string, bool>>();
    }

    public void AddVideoToQueue(Player player, VideoData videoData)
    {
        foreach (Player p in players)
        {
            downloadQueue[p].Add(videoData.VideoUrl, false);
        }

        cinemaManager.AddVideoToQueue(videoData);
    }

    public void PlayVideo(Player player, VideoData videoData)
    {
        downloadQueue[player][videoData.VideoUrl] = true;

        bool playVideo = true;
        foreach (Player p in players)
        {
            playVideo &= downloadQueue[p][videoData.VideoUrl];
        }

        if(playVideo)
        {
            cinemaManager.PlayTopVideo();
        }
    }

    public void DownloadFinished(VideoData videoData)
    {
        localPlayer.CmdFinishedDownloading(
            videoData.ThumbnailUrl,
            videoData.VideoUrl,
            videoData.VideoTitle);
    }

    public void VideoAdded(VideoData videoData)
    {
        localPlayer.CmdAddToQueue(
            videoData.ThumbnailUrl,
            videoData.VideoUrl,
            videoData.VideoTitle);
    }

    public void SetLocalPlayer(Player player)
    {
        localPlayer = player;
    }

    public void AddPlayer(Player player)
    {
        players.Add(player);
        downloadQueue.Add(player, new Dictionary<string, bool>());
    }
}
