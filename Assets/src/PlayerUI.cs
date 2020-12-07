using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    public GameObject[] imagenes;
    private InputControl inputControl;
    public int indice = 0;

    void Awake()
    {
        inputControl = new InputControl();
        UpdateImage();
    }

    public void UpdateImage()
    {  
        if (imagenes.Length > 0)
        {
            foreach (GameObject imagen in imagenes)
            {
                imagen.SetActive(false);
            }
            imagenes[indice].SetActive(true);
        }
       
    }

    public void onChange() 
    {
        float cambio = inputControl.UI.Press.ReadValue<float>();
        sumarIndice((int) cambio);
    }

    public void sumarIndice(int cambio)
    {
        indice += (int)cambio;
        if (indice < 0)
        {
            indice = imagenes.Length - 1;
        } else if (indice > imagenes.Length-1)
        {
            indice = 0;
        }
    }

    public void UpdateChange()
    {
        SendMessage("onChange");
    }
}
