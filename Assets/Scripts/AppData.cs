using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


[CreateAssetMenu(menuName = "AppData")]
public class AppData : ScriptableObject
{
    public List<Form> unfinishedForms;
    public List<Form> finishedForms;
    public string user;
    public int currentFormID;
    public int currentActivityID;

    public string token;
    
    private Dictionary<int, List<Texture2D>> activityPictures = new Dictionary<int, List<Texture2D>>();


    public void AddNewFormToUnfinishedFormsList(string text)
    {
        Form_list newForm = JsonUtility.FromJson<Form_list>(text);
        
        foreach (Form form in newForm.form_list)
        {
            bool isAlreadyInData = false;
            
            foreach (Form unfinishedForm in unfinishedForms)
            {
                if (unfinishedForm.id == form.id)
                {
                    isAlreadyInData = true;
                    break;
                }
            }
            
            if(!isAlreadyInData)
                unfinishedForms.Add(form);
        }
        Debug.Log(unfinishedForms.Count);
        
    }

    public List<Form> GetAllFormsInApp()
    {
        List<Form> allForms = new List<Form>();
        allForms = unfinishedForms.Concat(finishedForms).ToList();
        
        return allForms;
    }

    public List<Form> GetCompletedForms()
    {
        return finishedForms;
    }

    public void SaveNewPicturesFromActivity(int activityID, List<Texture2D> newPics)
    {
        if (activityPictures == null)
            return;
        
        activityPictures.Add(activityID, newPics);
    }
}
