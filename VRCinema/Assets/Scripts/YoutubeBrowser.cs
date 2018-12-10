using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YoutubeBrowser : MonoBehaviour
{
    private const int numVidsPerQuery = 12;

    [SerializeField]
    private CinemaManager cinemaManager;
    [SerializeField]
    private VideoImage videoImagePrefab;

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

        // @to-do remove when keyboard is added
        SearchVideos("How to tell if your cat is depressed");
    }

    public void SearchVideos(string query)
    {
        query = query.Replace(' ', '+');
        this.query = query;
        pageToken = 0;
        StartCoroutine(LoadVideoImages());
    }

    public void NextPage()
    {
        ++pageToken;
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
        videoImages.Add(Instantiate(videoImagePrefab, this.transform, false));
        videoImages[videoImages.Count - 1].Initialize(cinemaManager.AddVideoToQueue);
    }
}
