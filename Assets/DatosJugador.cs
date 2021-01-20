using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DatosJugador : MonoBehaviour
{

    Arbol[] arboles;
    Arbol activeArbol;

    private void Awake()
    {
        arboles = GetComponentsInChildren<Arbol>();
        foreach(Arbol arbol in arboles)
        {
            arbol.gameObject.SetActive(false);
            Debug.Log(arbol.gameObject.name);
        }
    }

    public void setActiveArbol(string name)
    {
        foreach(Arbol arbol in arboles)
        {
            if(arbol.name == name)
            {
                arbol.gameObject.SetActive(true);
                activeArbol = arbol;
            }
            else
            {
                arbol.gameObject.SetActive(false);
            }
        }
    }

    public Arbol getActiveArbol()
    {
        return activeArbol;
    }

    public void resetActiveArbol()
    {
        activeArbol.resetNodos();
    }

    public void nextActiveNodo()
    {
        activeArbol.changeNextNodo();
    }
}
