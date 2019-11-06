using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class StarPoint : MonoBehaviour, IPointerDownHandler
{
    public event Action<StarPoint> OnTouchedStar = delegate {  };
    public int score;
    [SerializeField]
    private Color _offColor;
    [SerializeField]
    private Color _onColor;
    
    public void TurnOff()
    {
        GetComponent<RawImage>().color = _offColor;
    }
    
    public void TurnOn()
    {
        GetComponent<RawImage>().color = _onColor;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnTouchedStar(this);
    }
}
