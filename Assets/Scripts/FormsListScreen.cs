using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormsListScreen : PanelDeListado
{
    protected override void PopulateList()
    {
        //Lleno la lista de formularios

        //Veo segun appData, la cantidad de formularios que hay sin realizar. Esta info viene del server.
        //Hago un boton de cada uno de los formularios. Cada formulario viene con sus datos dentro
        //El boton se crea con el nombre de formulario y se le da un ID. 
        //Se agrega al container
        //El boton lleva un evento donde llama al ScreenManager y le dice que hay que cambiar a otra pantalla y manda el ID.
    }
}
