using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LightJson;
using LightJson.Serialization;
using Extensions;

public class YoutubeSearch
{
    private const string baseURL = "https://www.googleapis.com/youtube/v3";
    private const string apiKey  = "AIzaSyBa3Rwz9Z58EHflU02m0LlQzmRdH1NnauQ";

    public List<VideoData> videos { get; private set; }
    private string pageToken = "";
    private string keywords = "cats";

    public IEnumerator QueryYoutubeSearch(string keywords)
    {
        string query = "";

        if(pageToken.Length == 0)
        {
            query = baseURL + "/search?part=snippet&maxResults=12&order=relevance&q=" + keywords + "&type=video&videoDefinition=high&key=" + apiKey;
        }
        else
        {
            query = baseURL + "/search?pageToken=" + pageToken + "&part=snippet&maxResults=12&order=relevance&q=" + keywords + "&type=video&videoDefinition=high&key=" + apiKey;
        }

        WWW page = new WWW(query);

        yield return page;

        ExtractSearch(page.text);
    }

    private string ExtractSearch(string page)
    {
        JsonObject json = JsonReader.Parse(page);
        videos.Clear();

        foreach(JsonObject item in json["items"].AsJsonArray)
        {
            Debug.Log(item);
            string thumbnail = item["snippet"].AsJsonObject["thumbnails"].AsJsonObject["high"].AsJsonObject["url"].AsString;
            string url = item["id"].AsJsonObject["videoId"].AsString;
            string title = item["snippet"].AsJsonObject["title"].AsString;

            videos.Add(new VideoData(thumbnail, url, title));
        }

        return page;
    }
}
