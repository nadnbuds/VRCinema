using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

[RequireComponent(typeof(Button))]
public class VideoImage : MonoBehaviour
{
    [SerializeField]
    private Image thumbnail;
    [SerializeField]
    private Text Title;
    [SerializeField]
    private Text Author;
    private VideoData videoData;
    private Button button;

    public void Initialize(Action<VideoData> onClick)
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(() => { onClick.Invoke(videoData); });
    }

    public void SetVideoData(VideoData videoData)
    {
        this.videoData = videoData;

        Title.text = videoData.VideoTitle;
        Author.text = videoData.VideoAuthor;
        StartCoroutine(RenderThumbnail(videoData.ThumbnailUrl));
    }

    IEnumerator RenderThumbnail(string url)
    {
        WWW page = new WWW(url);

        // Wait for download to complete
        yield return page;

        thumbnail.overrideSprite = Sprite.Create(page.texture, new Rect(0, 0, 480, 360), new Vector2(0.5f, 0.5f));
    }
}
