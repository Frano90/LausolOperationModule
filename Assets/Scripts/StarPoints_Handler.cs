using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarPoints_Handler : MonoBehaviour
{
    [SerializeField]
    private List<StarPoint> stars = new List<StarPoint>();

    private int _score;
    private void Awake()
    {
        RegisterStarCallBacks();
        
        ClearStars();
    }

    private void ClearStars()
    {
        for (int i = 0; i < stars.Count; i++)
        {
            stars[i].TurnOff();
        }
    }

    private void RegisterStarCallBacks()
    {
        foreach (StarPoint star in stars)
        {
            star.OnTouchedStar += UpdateScore;
        }
    }

    private void UpdateScore(StarPoint star)
    {
        //Despintar todas
        ClearStars();
        //Reseteo score
        _score = 0;
        //Pintar hasta la correcta
        for (int i = 0; i < star.score; i++)
        {
            _score++;
            stars[i].TurnOn();
        }
    }

    public int GetActivityScore()
    {
        return _score;
    }
    
    public void PaintStars(int score)
    {
        
        for (int i = 0; i < score; i++)
        {
            stars[i].TurnOn();
        }
    }
}
