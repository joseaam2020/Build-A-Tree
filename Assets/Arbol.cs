using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arbol : MonoBehaviour
{
    private Nodos[] nodos;
    private int currentNodo = 0; 

    private void Awake()
    {
        nodos = GetComponentsInChildren<Nodos>();

    }

    public void resetNodos()
    {
        foreach(Nodos nodo in nodos)
        {
            nodo.setLibre();
        }
        currentNodo = 0;
    }

    public void changeNextNodo()
    {
        nodos[currentNodo].changeNodoActual();
        currentNodo++;
    }
}
