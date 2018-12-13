using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YoutubeBrowser : MonoBehaviour
{
    private const int numVidsPerQuery = 12;

    [SerializeField]
    private VideoImage videoImagePrefab;
    [SerializeField]
    private GameObject searchPanel;
    [SerializeField]
    private Keyboard searchQuery;

    private YoutubeSearch youtubeSearch;
    private List<VideoImage> videoImages;
    private string query = "";
    private int pageToken = 0;

    private void Awake()
    {
        youtubeSearch = new YoutubeSearch();
        videoImages = new List<VideoImage>();

        for(int i = 0; i < numVidsPerQuery; ++i)
        {
            addNewVideoImageObject();
        }
    }

    public void NextPage()
    {
        ++pageToken;
        StartCoroutine(LoadVideoImages());
    }

    public void Search()
    {
        SearchVideos(searchQuery.EnterButton());
    }

    private void SearchVideos(string query)
    {
        searchPanel.gameObject.SetActive(true);
        query = query.Replace(' ', '+');
        this.query = query;
        pageToken = 0;
        StartCoroutine(LoadVideoImages());
    }

    private IEnumerator LoadVideoImages()
    {
        IEnumerator coroutine = youtubeSearch.QueryYoutubeSearch(query, pageToken);
        yield return StartCoroutine(coroutine);

        for(int i = 0; i < youtubeSearch.videos.Count; ++i)
        {
            if(i >= videoImages.Count)
            {
                addNewVideoImageObject();
            }

            videoImages[i].SetVideoData(youtubeSearch.videos[i]);
        }
    }

    private void addNewVideoImageObject()
    {
        videoImages.Add(Instantiate(videoImagePrefab, searchPanel.transform, false));
        videoImages[videoImages.Count - 1].Initialize(
            (VideoData data)=>
            {
                SyncManager.instance.VideoAdded(data);
                searchPanel.SetActive(false);
                searchQuery.OpenKeyboard();
            });
    }
}
