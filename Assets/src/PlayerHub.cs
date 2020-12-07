using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHub : MonoBehaviour
{
    public GameObject[] modelList;
    private GameObject activeModel;

    private void Awake()
    {
        foreach(GameObject model in modelList)
        {
            //Debug.Log(model.name.ToString());
            model.SetActive(false);
        }
    }

    public void setActiveModel(string name)
    {
        foreach(GameObject model in modelList)
        {
            Debug.Log(model.name + ":" + name);
            if(model.name.ToString() == name)
            {
                model.SetActive(true);
                activeModel = model;
                break;
            }
        }
    }

    public string getActiveModel()
    {
        return activeModel.name;
    }
}
