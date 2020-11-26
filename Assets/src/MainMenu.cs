using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void NextScene()
    {
        Debug.Log("Selected Button");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
