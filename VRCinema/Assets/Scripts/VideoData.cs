public struct VideoData
{
    public string ThumbnailUrl { get; private set; }
    public string VideoUrl { get; private set; }
    public string VideoTitle { get; private set; }
    public string VideoAuthor { get; private set; }

    public VideoData(string ThumbnailUrl, string VideoUrl, string VideoTitle, string VideoAuthor)
    {
        this.ThumbnailUrl = ThumbnailUrl;
        this.VideoUrl = VideoUrl;
        this.VideoTitle = VideoTitle;
        this.VideoAuthor = VideoAuthor;
    }

    public VideoData(VideoData videoData)
    {
        this.ThumbnailUrl = videoData.ThumbnailUrl;
        this.VideoUrl = videoData.VideoUrl;
        this.VideoTitle = videoData.VideoTitle;
        this.VideoAuthor = videoData.VideoAuthor;
    }
}
