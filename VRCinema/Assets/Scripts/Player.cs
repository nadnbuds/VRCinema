using UnityEngine;
using UnityEngine.Networking;

public class Player : NetworkBehaviour
{
    public override void OnStartAuthority()
    {
        SyncManager.instance.SetLocalPlayer(this);
        gameObject.name = "LocalPlayer";
    }

    private void Awake()
    {
        SyncManager.instance.AddPlayer(this);
    }

    [Command]
    public void CmdAddToQueue(
        string ThumbnailUrl,
        string VideoUrl,
        string VideoTitle)
    {
        RpcAddToQueue(
            ThumbnailUrl,
            VideoUrl,
            VideoTitle);
    }

    [ClientRpc]
    public void RpcAddToQueue(
        string ThumbnailUrl,
        string VideoUrl,
        string VideoTitle)
    {
        VideoData data = new VideoData(
            ThumbnailUrl,
            VideoUrl,
            VideoTitle);

        SyncManager.instance.AddVideoToQueue(this, data);
    }

    [Command]
    public void CmdFinishedDownloading(
        string ThumbnailUrl,
        string VideoUrl,
        string VideoTitle)
    {
        RpcFinishedDownloading(
            ThumbnailUrl,
            VideoUrl,
            VideoTitle);
    }

    [ClientRpc]
    public void RpcFinishedDownloading(
        string ThumbnailUrl,
        string VideoUrl,
        string VideoTitle)
    {
        VideoData data = new VideoData(
            ThumbnailUrl,
            VideoUrl,
            VideoTitle);

        SyncManager.instance.PlayVideo(this, data);
    }
}
