using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Player : MonoBehaviour
{
    [SyncVar(hook = "CheckDownloadComplete")]
    private float downloadProgress;

    private void CheckDownloadComplete()
    {
        if(downloadProgress >= 1)
        {
            
        }
    }
}
