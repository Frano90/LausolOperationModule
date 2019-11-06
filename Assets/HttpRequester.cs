using System;
using System.Collections;
using System.Collections.Generic;
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
    
    public void GetJsonWithToken(string url, Action<string> callback, string token)
    {
        StartCoroutine(UnityGetJson(url, callback, token));
    }

    public void PostJsonWithToken(string url, string jsonParams, Action<string> callback, string token)
    {
        StartCoroutine(UnityPostJson(url, jsonParams, callback, token));
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
    
    private IEnumerator UnityGetJson(string url, Action<string> callback, string token)
    {
        UnityWebRequest uwr = UnityWebRequest.Get(url);
        uwr.SetRequestHeader("Content-Type", "application/json");
        uwr.SetRequestHeader("Accept", "application/json");
        
        if (token != null)
        {
            uwr.SetRequestHeader( "X-User-Token",token);
        }
        
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
    
    private IEnumerator UnityPostJson(string url, string jsonParams, Action<string> callback, string token)
    {
        UnityWebRequest uwr = UnityWebRequest.Post(url, "");
        byte[] paramBytes = new System.Text.UTF8Encoding().GetBytes(jsonParams);
        uwr.uploadHandler = new UploadHandlerRaw(paramBytes);
        uwr.downloadHandler = new DownloadHandlerBuffer();
        uwr.SetRequestHeader("Content-Type", "application/json");
        uwr.SetRequestHeader("Accept", "application/json");
        
        if (token != null)
        {
            uwr.SetRequestHeader( "X-User-Token",token);
        }
        
        
        yield return uwr.SendWebRequest();

        while (!uwr.downloadHandler.isDone)
            yield return new WaitForEndOfFrame();

        callback(uwr.isNetworkError ? uwr.error : uwr.downloadHandler.text);
        yield break;
    }
}
