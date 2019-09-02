using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Se encarga de ir cambiando las diferentes pantallas
//la idea es que todos los botones lo conozcan, cosa que cuando se presiona uno, este mismo lo llame diciendole que
//tipo de pantalla es la siguiente que tiene que poner. Luego, hace que esa pantalla se inicialice.
public class ScreenManager : MonoBehaviour
{
    ScreenPanel currentPanel;



    public ScreenPanel ChangePanel(ScreenPanel nextPanel)
    {

        currentPanel = nextPanel;
        return currentPanel;
    }
}
