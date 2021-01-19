using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Carga la siguiente escena en Menu principal 
/// </summary>
public class MainMenu : MonoBehaviour
{
    /// <summary>
    /// Carga la siguiente escena 
    /// </summary>
    public void OnPlayerJoined()
    {
        Debug.Log("Selected Button");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
