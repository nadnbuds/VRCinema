using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LightJson;
using LightJson.Serialization;

public class YoutubeSearch : MonoBehaviour
{
    [SerializeField]
    private VideoData video;
    private const string baseURL = "https://www.googleapis.com/youtube/v3";
    private const string apiKey  = "AIzaSyBa3Rwz9Z58EHflU02m0LlQzmRdH1NnauQ";

    private string pageToken = "";
    private string keywords = "cats";

    private void Awake()
    {
        StartCoroutine(QueryYoutubeSearch(keywords));
    }

    private IEnumerator QueryYoutubeSearch(string keywords)
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
        Debug.Log(page);

        JsonObject json = JsonReader.Parse(page);

        foreach(JsonObject item in json["items"].AsJsonArray)
        {
            Debug.Log(item);

            video.SetThumbnail(item["snippet"].AsJsonObject["thumbnails"].AsJsonObject["high"].AsJsonObject["url"].AsString);
            video.SetURL(item["id"].AsJsonObject["videoId"].AsString);

        }


        return page;
    }
}
