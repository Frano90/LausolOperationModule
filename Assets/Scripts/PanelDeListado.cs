using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelDeListado : ScreenPanel
{
    public GameObject listContainer;

    public void OnEnable()
    {
        //cada vez que entro a este panel lo actualizo
        Refresh();
    }

    protected virtual void Refresh()
    {
        //Actualizo lista de formularios sin terminar
    }


    public void AddNewBGOtoContainer(GameObject go)
    {
        //Agrego formularios sin terminar a la lista       
    }

    protected virtual void PopulateList()
    {
        
    }

    private void EmptyList()
    {
        //Vacio la lista de formularios
    }

    private void CreateUnfinishedForms()
    {
        //Creo un formulario
    }
}
