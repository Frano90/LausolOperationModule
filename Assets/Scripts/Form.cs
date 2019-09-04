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

    public int relevamientosID;
    public int clientID;
    public string clientName;
    public int locationID;
    public string locationName;
    public string locationAddress;
    public List<Activity> relevamientos;

}
