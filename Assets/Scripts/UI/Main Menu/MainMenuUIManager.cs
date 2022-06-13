using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenuUIManager : MonoBehaviour
{
    public static MainMenuUIManager instance;

    private void Awake()
    {
        instance = this;
    }

    public void StartButton()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void ExitButton()
    {
        Application.Quit();
    }

   
}
