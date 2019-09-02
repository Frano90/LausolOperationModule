using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class HttpRequester : MonoBehaviour
{
    public void GetJson(string url, Action<string> callback)
    {
        StartCoroutine(UnityGetJson(url, callback));
    }

    public void PostJson(string url, string jsonParams, Action<string> callback)
    {
        StartCoroutine(UnityPostJson(url, jsonParams, callback));
    }

    private IEnumerator UnityGetJson(string url, Action<string> callback)
    {
        UnityWebRequest uwr = UnityWebRequest.Get(url);
        uwr.SetRequestHeader("Content-Type", "application/json");
        uwr.SetRequestHeader("Accept", "application/json");
        yield return uwr.SendWebRequest();

        while (!uwr.downloadHandler.isDone)
            yield return new WaitForEndOfFrame();

        callback(uwr.isNetworkError ? uwr.error : uwr.downloadHandler.text);
        yield break;
    }
    
    private IEnumerator UnityPostJson(string url, string jsonParams, Action<string> callback)
    {
        UnityWebRequest uwr = UnityWebRequest.Post(url, "");
        byte[] paramBytes = new System.Text.UTF8Encoding().GetBytes(jsonParams);
        uwr.uploadHandler = new UploadHandlerRaw(paramBytes);
        uwr.downloadHandler = new DownloadHandlerBuffer();
        uwr.SetRequestHeader("Content-Type", "application/json");
        uwr.SetRequestHeader("Accept", "application/json");
        yield return uwr.SendWebRequest();

        while (!uwr.downloadHandler.isDone)
            yield return new WaitForEndOfFrame();

        callback(uwr.isNetworkError ? uwr.error : uwr.downloadHandler.text);
        yield break;
    }
}
