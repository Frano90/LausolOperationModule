using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivityFormListScreen : PanelDeListado
{
    protected override void PopulateList()
    {
        //Lleno la lista de actividades del formulario

        //Busco segun el ID recibido el formulario
        //Hago un boton de cada uno de las actividades dentro del formulario
        //El boton se crea con el nombre de la actividad
        //Se agrega al container
        //El boton lleva un evento donde llama al ScreenManager y le dice que hay que cambiar a otra pantalla-de actividad a relevar.
    }
}
