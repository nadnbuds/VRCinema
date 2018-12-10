using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using System.Collections.Generic;

public class VideoDataList : SyncListStruct<VideoData> { }

public class SyncManager : NetworkBehaviour
{
    [SerializeField]
    private CinemaManager cinemaManager;

    private int playerDownloadsFinished = 0;
    public VideoDataList VideoQueue;

    private void Awake()
    {
        VideoQueue = new VideoDataList();
    }

    [Command]
    public void CmdDownloadFinished()
    {
        playerDownloadsFinished++;
        if(playerDownloadsFinished >= NetworkManager.singleton.numPlayers)
        {
            cinemaManager.RpcPlayTopVideo();
        }
    }

    [Command]
    public void CmdAddVideoToQueue(VideoData videoData)
    {
        VideoQueue.Add(new VideoData(videoData));

        cinemaManager.RpcStartVideoDownload(videoData);
    }
}
