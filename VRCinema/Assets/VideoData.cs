using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VideoData : MonoBehaviour
{
    [SerializeField]
    private Image thumbnail;
    [SerializeField]
    private CinemaManager cinemaManager;
    private Button playButton;
    private string url;

    private void Awake()
    {
        playButton = GetComponent<Button>();
        playButton.onClick.AddListener(playVideo);
    }

    public void SetThumbnail(string val)
    {
        StartCoroutine(RenderThumbnail(val));
    }

    public void SetURL(string val)
    {
        url = "https://www.youtube.com/watch?v=" + val + "&hd=1";
    }

    IEnumerator RenderThumbnail(string url)
    {
        WWW page = new WWW(url);

        // Wait for download to complete
        yield return page;

        thumbnail.overrideSprite = Sprite.Create(page.texture, new Rect(0, 0, 480, 360), new Vector2(0.5f, 0.5f));
    }

    private void playVideo()
    {
        cinemaManager.PlayVideo(url);
    }
}
