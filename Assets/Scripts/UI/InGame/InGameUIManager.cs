using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameUIManager : MonoBehaviour
{
    [SerializeField] GameObject _pauseButton;
    [SerializeField] GameObject _pausedPanel;

    bool _paused = false;

    public bool isPasued => _paused;

    public void PauseButton()
    {
        _paused = true;
        _pauseButton.SetActive(false);
        _pausedPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ResumeButton()
    {
        _paused = false;
        _pauseButton.SetActive(true);
        _pausedPanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void GoMenu()
    {
        ResumeButton();
        SceneManager.LoadScene(0);
    }
}
