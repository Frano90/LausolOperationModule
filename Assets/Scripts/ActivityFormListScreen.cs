using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActivityFormListScreen : PanelDeListado
{
    [HideInInspector]
    public Button activityButton_prefab;

    protected override void PopulateList()
    {
        //Lleno la lista de actividades del formulario

        //Busco segun el ID recibido el formulario
        //Hago un boton de cada uno de las actividades dentro del formulario
        //El boton se crea con el nombre de la actividad
        //Se agrega al container
        //El boton lleva un evento donde llama al ScreenManager y le dice que hay que cambiar a otra pantalla-de actividad a relevar.

        foreach (var form in appData.unfinishedForms)
        {
            if(form.relevamientosID == appData.currentFormID)
            {
                foreach (var activity in form.relevamientos)
                {
                    Button newButton = Instantiate(activityButton_prefab, listContainer.transform);
                    newButton.onClick.AddListener(delegate { screenManager.ChangePanel(ScreenManager.ScreenType.activity); });
                    newButton.gameObject.GetComponentInChildren<Text>().text = activity.activityName;
                    botones.Add(newButton);
                }
            }
        }
    }
}
