using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenPanel : MonoBehaviour
{
    //Es la clase del tipo pantalla. 
    //Todas las pantallas de la app heredan de aca.
    [HideInInspector]
    public string panelName;
    
    [HideInInspector]
    public AppData appData;
    
    [HideInInspector]
    public ScreenManager screenManager;
    
    public ScreenManager.ScreenType panelType;
    
    [HideInInspector]
    public Button prevButton;
    
    internal List<Button> botones = new List<Button>();

    internal virtual void Awake()
    {
        if (prevButton != null)
            prevButton.onClick.AddListener(screenManager.GoToPreviousScreen);
    }

    internal virtual void UnregisterButtonEvents()
    {
        foreach (var b in botones)
        {
            b.onClick.RemoveAllListeners();
        }
        Debug.Log("Desregistro todo");

        if(prevButton != null)
            prevButton.onClick.RemoveAllListeners();
    }

}
