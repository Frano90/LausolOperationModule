using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ButtonHandler : MonoBehaviour
{
    [Header("Setup")]
    public HttpRequester httpRequester;
    public TextMeshProUGUI result;
    
    [Header("GET")]
    public string urlGet;
    public Button getButton;
    public Button.ButtonClickedEvent getButtonEvent;

    [Header("POST")]
    public string urlPost;
    public Button postButton;
    public string postJsonParams;
    public Button.ButtonClickedEvent postButtonEvent;

    private void Start()
    {
        getButton.onClick = getButtonEvent;
        postButton.onClick = postButtonEvent;
    }

    public void GetRequest()
    {
        httpRequester.GetJson(urlGet, UpdateResultText);
    }

    public void PostRequest()
    {
        httpRequester.PostJson(urlPost, postJsonParams, UpdateResultText);
    }

    private void UpdateResultText(string requestResponse)
    {
        result.text = requestResponse;
    }
}
