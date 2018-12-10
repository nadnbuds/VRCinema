﻿public struct VideoData
{
    public string ThumbnailUrl { get; private set; }
    public string VideoUrl { get; private set; }
    public string VideoTitle { get; private set; }

    public VideoData(string ThumbnailUrl, string VideoUrl, string VideoTitle)
    {
        this.ThumbnailUrl = ThumbnailUrl;
        this.VideoUrl = "https://www.youtube.com/watch?v=" + VideoUrl + "&hd=1";
        this.VideoTitle = VideoTitle;
    }

    public VideoData(VideoData videoData)
    {
        this.ThumbnailUrl = videoData.ThumbnailUrl;
        this.VideoUrl = videoData.VideoUrl;
        this.VideoTitle = videoData.VideoTitle;
    }
}
