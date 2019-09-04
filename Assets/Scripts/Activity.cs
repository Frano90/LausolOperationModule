using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Activity
{
    //Los parametros de la actividad son:
    //Nombre de la actividad
    //Calificacion
    //Lista de imagenes
    //Observaciones del supervisor
    //Observaciones del server

    public string activityName;
    public int score;
    public List<Texture2D> imagenes;
    public string supervisorObs;
    public string serverObs;
}
