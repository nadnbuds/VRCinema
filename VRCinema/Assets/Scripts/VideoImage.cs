using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(Button))]
public class VideoImage : MonoBehaviour
{
    [SerializeField]
    private Image thumbnail;
    private VideoData videoData;
    private Button button;

    private void Awake()
    {
        button = GetComponent<Button>();
    }

    private void SetVideoData(VideoData videoData)
    {
        this.videoData = videoData;
    }

    IEnumerator RenderThumbnail(string url)
    {
        WWW page = new WWW(url);

        // Wait for download to complete
        yield return page;

        thumbnail.overrideSprite = Sprite.Create(page.texture, new Rect(0, 0, 480, 360), new Vector2(0.5f, 0.5f));
    }
}
