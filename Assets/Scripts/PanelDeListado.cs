using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelDeListado : ScreenPanel
{
    public GameObject listContainer;

    protected virtual void OnEnable()
    {
        PopulateList();
    }

    protected virtual void PopulateList()
    {
        
    }

}
