using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Networking;

public class Player : NetworkBehaviour
{
    public override void OnStartAuthority()
    {
        for(int i = 0; i < transform.childCount; ++i)
        {
            transform.GetChild(i).gameObject.SetActive(true);
        }

        GetComponent<OVRPlayerController>().enabled = true;
        GetComponent<MeshRenderer>().enabled = false;
        OVRCameraRig cameraRig = GetComponentInChildren<OVRCameraRig>();
        SyncManager.instance.SetLocalPlayer(this);
        GameObject.Find("EventSystem").AddComponent<OVRInputModule>().rayTransform = cameraRig.transform;
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
        string VideoTitle,
        string VideoAuthor)
    {
        RpcAddToQueue(
            ThumbnailUrl,
            VideoUrl,
            VideoTitle,
            VideoAuthor);
    }

    [ClientRpc]
    public void RpcAddToQueue(
        string ThumbnailUrl,
        string VideoUrl,
        string VideoTitle,
        string VideoAuthor)
    {
        VideoData data = new VideoData(
            ThumbnailUrl,
            VideoUrl,
            VideoTitle,
            VideoAuthor);

        SyncManager.instance.AddVideoToQueue(this, data);
    }

    [Command]
    public void CmdFinishedDownloading(
        string ThumbnailUrl,
        string VideoUrl,
        string VideoTitle,
        string VideoAuthor)
    {
        RpcFinishedDownloading(
            ThumbnailUrl,
            VideoUrl,
            VideoTitle,
            VideoAuthor);
    }

    [ClientRpc]
    public void RpcFinishedDownloading(
        string ThumbnailUrl,
        string VideoUrl,
        string VideoTitle,
        string VideoAuthor)
    {
        VideoData data = new VideoData(
            ThumbnailUrl,
            VideoUrl,
            VideoTitle,
            VideoAuthor);

        SyncManager.instance.PlayVideo(this, data);
    }
}
