using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActivityScreen : ScreenPanel
{
    
    private List<Texture2D> pics = new List<Texture2D>();
    [HideInInspector]
    public PhotoGallery photoGallery_prefab;
    
    private PhotoGallery currentGallery;
    private Form _currentForm;
    private Activity _currentActivity;

    [SerializeField] 
    private Text title;

    [SerializeField]
    private Text detailBox;

    [SerializeField] private InputField _observaciones;

    [SerializeField] private Button _save_Btt;
    [SerializeField]
    private StarPoints_Handler _starPointsHandler;
    
    

    internal override void Awake()
    {
        base.Awake();
        currentGallery = Instantiate(photoGallery_prefab, transform);
        _starPointsHandler = FindObjectOfType<StarPoints_Handler>();
        
        _currentActivity = LookForCurrentActivity();
        FillFields();
        
        _save_Btt.onClick.AddListener(SaveData);
    }

    private void Start()
    {
        FillFields();
    }

//    private IEnumerator FillData()
//    {
//        yield return null;
//        _currentActivity = LookForCurrentActivity();
//        
//        FillFields();
//    }

    private void SaveData()
    {
        _currentActivity.response_score = _starPointsHandler.GetActivityScore();
        _currentActivity.response_message = _observaciones.text;


        _currentActivity.images = currentGallery.pics;
        //appData.SaveNewPicturesFromActivity(_currentActivity.id, currentGallery.pics);
    }

    #region FillData
    private Activity LookForCurrentActivity()
    {
        List<Form> allForms = appData.GetAllFormsInApp();
        
        for (int i = 0; i < allForms.Count; i++)
        {
            if (allForms[i].id == appData.currentFormID)
            {
                _currentForm = allForms[i];

                for (int j = 0; j < _currentForm.activities.Length; j++)
                {
                    if (_currentForm.activities[j].id == appData.currentActivityID)
                    {
                        return  _currentForm.activities[j];
                    }
                }
            }
        }

        return null;
    }

    private void FillFields()
    {
        if (_currentActivity == null)
            return;
        
        title.text = _currentActivity.title;
        detailBox.text = _currentActivity.detail;
        _starPointsHandler.PaintStars(_currentActivity.response_score);
        _observaciones.text = _currentActivity.response_message;
        currentGallery.pics = _currentActivity.images;
    }

   

    

    #endregion

    #region Photos

    public void TakePicture(int maxSize)
    {
        NativeCamera.Permission permission = NativeCamera.TakePicture((path) =>
        {
            Debug.Log("Image path: " + path);
            if (path != null)
            {
                // Create a Texture2D from the captured image
                Texture2D texture = NativeCamera.LoadImageAtPath(path, maxSize);
                if (texture == null)
                {
                    Debug.Log("Couldn't load texture from " + path);
                    return;
                }
                AddPicToGallery(texture);
            }
        }, maxSize);

        Debug.Log("Permission result: " + permission);


    }

    private void AddPicToGallery(Texture2D texture)
    {
        currentGallery.AddPicToGallery(texture);
    }

    public void GoToGallery()
    {
        if(currentGallery != null)
            currentGallery.gameObject.SetActive((!currentGallery.gameObject.activeInHierarchy));
    }

    #endregion
    
    
}
