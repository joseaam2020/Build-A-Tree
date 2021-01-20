using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nodos : MonoBehaviour
{
    public GameObject nodoLibre;
    public GameObject nodoOcupado;
    private GameObject nodoActual;
    private GameObject[] nodos;

    private void Awake()
    {
        nodoActual = nodoLibre;
        nodos = new GameObject[2];
        nodos[0] = nodoLibre;
        nodos[1] = nodoOcupado;
        nodoActual.SetActive(true);
        nodoOcupado.SetActive(false);
    }

    public void changeNodoActual()
    {
        nodoActual.SetActive(false);
        foreach (GameObject nodo in nodos)
        {
            if (!nodoActual.Equals(nodo))
            {
                nodoActual = nodo;
            }
        } nodoActual.SetActive(true);
    }

    public void setLibre()
    {
        if (!nodoActual.Equals(nodoLibre))
        {
            nodoActual.SetActive(false);
            nodoActual = nodoLibre;
            nodoActual.SetActive(true);
        }
    }

}
