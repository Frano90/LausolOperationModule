using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhotoGallery : ScreenPanel
{
    public GameObject container;
    List<Texture2D> pics = new List<Texture2D>();

    public void OnEnable()
    {
        foreach (var pic in pics)
        {
            RawImage img = new GameObject("Photo").AddComponent<RawImage>();
            img.GetComponent<RectTransform>().sizeDelta = new Vector2(512, 512);
            img.gameObject.transform.SetParent(container.transform);
            img.texture = pic;
        }
    }

    public void OnDisable()
    {
        foreach (Transform imagenes in container.transform)
        {
            if (imagenes.gameObject != null)
                Destroy(imagenes.gameObject);
        }
    }

    public void AddPicToGallery(Texture2D pic)
    {
        pics.Add(pic);
    }
}
