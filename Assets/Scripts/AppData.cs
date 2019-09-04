using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AppData")]
public class AppData : ScriptableObject
{
    public List<Form> unfinishedForms;
    public List<Form> finishedForms;
    public string user;
    public int currentFormID;
}
