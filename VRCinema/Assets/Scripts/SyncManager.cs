using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using System.Collections.Generic;

public class SyncManager : NetworkBehaviour
{
    [SerializeField]
    private CinemaManager cinemaManager;

    private int playerCount = 0;
    private int playerDownloadsFinished = 0;
    public Queue<VideoData> VideoQueue;

    private void Awake()
    {
        VideoQueue = new Queue<VideoData>();
    }

    private void OnPlayerConnected(NetworkIdentity player)
    {
        playerCount++;
    }

    private void OnPlayerDisconnected(NetworkIdentity player)
    {
        playerCount--;
    }

    [Command]
    public void CmdDownloadFinished()
    {
        playerDownloadsFinished++;
        if(playerDownloadsFinished >= playerCount)
        {
            cinemaManager.PlayTopVideo();
        }
    }

    [Command]
    public void CmdAddVideoToQueue(VideoData videoData)
    {
        VideoQueue.Enqueue(videoData);
    }
}
