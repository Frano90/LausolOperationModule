using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class FormsListScreen : PanelDeListado
{
    public Button formListButton_prefab;
    public Button refreshForms_prefab;
    
    [SerializeField]
    private Button sendCompletedForms_Btt;

    public string url_FormsCompletedPost;

    public HttpRequester pf_HttpRequester;
    private HttpRequester httpRequester;
    public string urlGet;
    

    private void Awake()
    {
        httpRequester = Instantiate(pf_HttpRequester, transform);
        sendCompletedForms_Btt.onClick.AddListener(SendCompletedForms);
        
        
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        //GetRequest();
    }

    private void SendCompletedForms()
    {
        Form_list newJson = new Form_list();
        newJson.form_list = new List<Form>();
        foreach (Form form in appData.GetCompletedForms())
        {
            newJson.form_list.Add(form);
        }

        string jsonCode = JsonUtility.ToJson(newJson);
        httpRequester.PostJsonWithToken(url_FormsCompletedPost,jsonCode, Debug.Log, appData.token);
    }

    public void GetRequest()
    {
        httpRequester.GetJson(urlGet, RefreshFormulario);
    }
    protected override void PopulateList()
    {
        Debug.Log("Lleno la lista de formularios");
        //Lleno la lista de formularios

        //Veo segun appData, la cantidad de formularios que hay sin realizar. Esta info viene del server.
        //Hago un boton de cada uno de los formularios. Cada formulario viene con sus datos dentro
        //El boton se crea con el nombre de formulario y se le da un ID. 
        //Se agrega al container
        //El boton lleva un evento donde llama al ScreenManager y le dice que hay que cambiar a otra pantalla y manda el ID.


        foreach (Button b in botones)
        {
            Destroy(b.gameObject);
        }
        botones.Clear();
        
        
        foreach (var form in appData.unfinishedForms)
        {
            Button newButton = Instantiate(formListButton_prefab, listContainer.transform);
            newButton.onClick.AddListener(delegate { appData.currentFormID = form.id; });
            newButton.onClick.AddListener(delegate { screenManager.ChangePanel(ScreenManager.ScreenType.formActivity); });
            newButton.GetComponentInChildren<Text>().text = form.client_name + "\n" + form.location_address;
            botones.Add(newButton);
        }
    }

    public void RefreshFormulario(string requestResponse)
    {
        appData.AddNewFormToUnfinishedFormsList(requestResponse);
        PopulateList();
    }
}
