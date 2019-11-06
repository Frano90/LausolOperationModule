using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Form
{
    //Definir los datos que va a contener el formulario.
    //Titulo
    //Cliente/sucursal
    //ID
    //Observaciones al generar desde server
    //Observaciones generales del supervisor
    //Fecha de generacion
    //Fecha de caducidad
    //Supervisor designado
    //estado de realizacion
    //Lista de actividades a revisar
    //Puntaje final


    public int id;
    public int client_id;
    public string client_name;
    public int location_id;
    public string location_name;
    public string location_address;
    public string creation_date;
    public string expiration_date;
    public string completion_date;
    public int total_score;
    public Activity[] activities;

}
