using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoginScreen : ScreenPanel
{
    
    [SerializeField]
    private HttpRequester pf_httpRequester;
    private HttpRequester _httpRequester;

    [SerializeField]
    private InputField user;
    [SerializeField]
    private InputField pass;

    [SerializeField] 
    private Button _logInButton;

    [Header("URL to logIn")] 
    [SerializeField]
    private string _url;

    [SerializeField] private string _urlImage;

    private string token = "";

    public Texture2D image;
    public Button sendNudesButton;

    internal override void Awake()
    {
        base.Awake();
        _httpRequester = Instantiate<HttpRequester>(pf_httpRequester);
    }
    private void Start()
    {
        _logInButton.onClick.AddListener(LogIn);
        sendNudesButton.onClick.AddListener(SendPicture);
    }


    private void LogIn()
    {
        LogIn_Request logInRequest = new LogIn_Request();
        logInRequest.email = user.text;
        logInRequest.password = pass.text;

        string logInJson = JsonUtility.ToJson(logInRequest);

        _httpRequester.PostJsonWithToken(_url, logInJson, ShowToken, token);
    }

    private void SendPicture()
    {
        Image_Request imageRq = new Image_Request();
        imageRq.image = image.EncodeToPNG();

        string jsonImage = JsonUtility.ToJson(imageRq);
        
        _httpRequester.PostJsonWithToken(_urlImage, jsonImage, Debug.Log, token);

    }
    private void ShowToken(string jsonResponse)
    {
        
        
        LogIn_Response logIn_response = JsonUtility.FromJson<LogIn_Response>(jsonResponse);
        
        Debug.Log(logIn_response.token);
        Debug.Log(logIn_response.message);

        if (logIn_response.message == "Login OK")
        {
            screenManager.ChangePanel(ScreenManager.ScreenType.mainMenu);    
        }
        else
        {
            Debug.Log("Incorrect pass or user");
        }
        
        
    }

//    private void ImageResult(string jsonResponse)
//    {
//        JsonUtility.FromJson<Image_Request>(jsonResponse);
//    }
    
    
}
