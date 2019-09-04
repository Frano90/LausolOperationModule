using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActivityScreen : ScreenPanel
{
    private List<Texture2D> pics = new List<Texture2D>();
    public PhotoGallery photoGallery_prefab;
    PhotoGallery currentGallery;


    internal override void Awake()
    {
        base.Awake();
        currentGallery = Instantiate(photoGallery_prefab, transform);
    }

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
}
