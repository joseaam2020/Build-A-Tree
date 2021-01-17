using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Se encarga de almacenar todos los modelos de los personajes para cada jugador.
/// De esta manera qe puede decidir cual model utilizar. 
/// </summary>
public class PlayerHub : MonoBehaviour
{
    public GameObject[] modelList;
    private GameObject activeModel;

    private void Awake()
    {
        foreach(GameObject model in modelList)
        {
            //Se deshabilitan todos los modelos
            model.SetActive(false);
        }
    }

    /// <summary>
    /// Habilita el modelo seleccionado
    /// </summary>
    /// <param name="name">Modelo seleccionado</param>
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

    /// <summary>
    /// Retorna el nombre del modelo seleccionado.
    /// </summary>
    /// <returns>Nombre del modelo seleccionado como string</returns>
    public string getActiveModel()
    {
        return activeModel.name;
    }
}
