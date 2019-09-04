using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : ScreenPanel
{
    public Button unfinishedForms;
    public Text text;

    private void OnEnable()
    {
        unfinishedForms.onClick.AddListener(delegate {screenManager.ChangePanel(ScreenManager.ScreenType.listForm); });
    }

 
}
