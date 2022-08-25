using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameUIManager : MonoBehaviour
{
    public static InGameUIManager instance;
    [SerializeField] GameObject _pauseButton;
    [SerializeField] GameObject _pausedPanel;
    [SerializeField] GameObject _touchControls;
    bool _paused = false;

    public bool isPasued => _paused;

    private void Awake()
    {
        instance = this;
    }

    public void PauseButton()
    {
        DisableTouchControl();
        _paused = true;
        _pauseButton.SetActive(false);
        _pausedPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ResumeButton()
    {
        EnableTouchControl();
        _paused = false;
        _pauseButton.SetActive(true);
        _touchControls.SetActive(true);
        _pausedPanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }
    public void GoMenu()
    {
        ResumeButton();
        SceneManager.LoadScene(0);
    }

    public void EnableTouchControl()
    {
        _touchControls.SetActive(true);
    }

    public void DisableTouchControl()
    {
         _touchControls.SetActive(false);
    }
}
