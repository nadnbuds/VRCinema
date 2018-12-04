using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using System.Collections.Generic;

public class SyncManager : MonoBehaviour
{
    private int playerCount = 0;
    private int playerDownloadsFinished = 0;

    private void OnPlayerConnected(NetworkPlayer player)
    {
        playerCount++;
    }

    private void OnPlayerDisconnected(NetworkPlayer player)
    {
        playerCount--;
    }

    [Command]
    public void CmdDownloadFinished()
    {
        playerDownloadsFinished++;
        if(playerDownloadsFinished >= playerCount)
        {

        }
    }
}
