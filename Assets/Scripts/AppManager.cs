using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppManager : MonoBehaviour
{
    public AppData appData;
    public ScreenManager screenManager;
    

    private void Awake()
    {
        screenManager.Init();
    }
}
