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
    
    public int id;
    public string start_date;
    public string completion_date;
    public string title;
    public string detail;
    public string response_message;
    public int response_score;
    public List<Texture2D> images;
    
}
