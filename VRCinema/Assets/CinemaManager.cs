using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class CinemaManager : MonoBehaviour
{
    [SerializeField]
    private VideoPlayer videoPlayer;

    public void PlayVideo(string url)
    {
        videoPlayer.url = url;
        videoPlayer.Play();
    }
}
