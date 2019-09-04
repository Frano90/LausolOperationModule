using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Se encarga de ir cambiando las diferentes pantallas
//la idea es que todos los botones lo conozcan, cosa que cuando se presiona uno, este mismo lo llame diciendole que
//tipo de pantalla es la siguiente que tiene que poner. Luego, hace que esa pantalla se inicialice.
[CreateAssetMenu(fileName = "ScreenManager", menuName = "ScreenManager")]
public class ScreenManager : ScriptableObject
{
    public ScreenPanel listadoFormPanel_prefab;
    public ScreenPanel listadoActivityFormPanel_prefab;
    public ScreenPanel activityPanel_prefab;
    public ScreenPanel mainMenuPanel_prefab;
    Canvas canvas;

    ScreenType prevScrenPanel;
    ScreenPanel currentPanel;
    public AppData appData;

    public void Init()
    {
        canvas = FindObjectOfType<Canvas>();

        RemoveCurrentScreenPanel();
        currentPanel = ChangePanel(ScreenType.mainMenu);
    }


    public ScreenPanel ChangePanel(ScreenType nextPanel)
    {
        RemoveCurrentScreenPanel();

        ScreenPanel newScreen = default;
        switch (nextPanel)
        {
            case ScreenType.listForm:
                newScreen = Instantiate(listadoFormPanel_prefab, canvas.transform);
                break;
            case ScreenType.formActivity:
                newScreen = Instantiate(listadoActivityFormPanel_prefab, canvas.transform);
                break;
            case ScreenType.activity:
                newScreen = Instantiate(activityPanel_prefab, canvas.transform);
                break;
            case ScreenType.mainMenu:
                newScreen = Instantiate(mainMenuPanel_prefab, canvas.transform);
                break;
            default:
                break;
        }
        newScreen.gameObject.SetActive(true);
        currentPanel = newScreen;
        return newScreen;

    }

    private void RemoveCurrentScreenPanel()
    {
        if (currentPanel != null)
        {
            currentPanel.UnregisterButtonEvents();
            prevScrenPanel = currentPanel.panelType;
            Destroy(currentPanel.gameObject);
        }

        
        currentPanel = null;
    }

    public void GoToPreviousScreen()
    {
        Debug.Log("Vuelvooo");
        ScreenType newScreen = default;

        switch (currentPanel.panelType)
        {
            case ScreenType.listForm:
                newScreen = ScreenType.mainMenu;
                break;
            case ScreenType.formActivity:
                newScreen = ScreenType.listForm;
                break;
            case ScreenType.activity:
                
                newScreen = ScreenType.formActivity;
                break;
            case ScreenType.mainMenu:
                break;
            default:
                break;
        }

        ChangePanel(newScreen);
    }

    public enum ScreenType
    {
        listForm,
        formActivity,
        activity,
        mainMenu,
        gallery
    }
}
