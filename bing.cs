using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using SimpleJSON;
using UnityEngine.UI;
public class bing : MonoBehaviour
{
    
    public RawImage rawImage;


    void Start()
    {
        // A correct website page.
        StartCoroutine(GetRequest("http://www.bing.com/HPImageArchive.aspx?format=js&idx=0&n=1"));

        // A non-existing page.
       // StartCoroutine(GetRequest("https://error.html"));
    }

    IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            string[] pages = uri.Split('/');
            int page = pages.Length - 1;

            if (webRequest.isNetworkError)
            {
                Debug.Log(pages[page] + ": Error: " + webRequest.error);
            }
            else
            {
                Debug.Log(pages[page] + ":\nReceived: " + webRequest.downloadHandler.text);
                string INFO = webRequest.downloadHandler.text;
                JsonUtility.ToJson(INFO);
                var N = JSON.Parse(INFO);
                Debug.Log(N);
                string ImageURL = "http://bing.com"+ (N[0][0]["url"]);
                Debug.Log(ImageURL);
                StartCoroutine(DownloadImage(ImageURL));
            }
        }
    }

    IEnumerator DownloadImage(string MediaUrl)
    {
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(MediaUrl);
        yield return request.SendWebRequest();
        if (request.isNetworkError || request.isHttpError)
            Debug.Log(request.error);
        else
            rawImage.texture = ((DownloadHandlerTexture)request.downloadHandler).texture;
    }

}
