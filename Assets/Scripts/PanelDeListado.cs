using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelDeListado : ScreenPanel
{
    public GameObject listContainer;

    private void OnEnable()
    {
        PopulateList();
    }

    protected virtual void PopulateList()
    {
        
    }

}
