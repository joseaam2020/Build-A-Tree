using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHub : MonoBehaviour
{

    [SerializeField] public GameObject[] modelList;

    private void Awake()
    {
        foreach(GameObject model in modelList)
        {
            model.SetActive(false);
        }
    }
}
