using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    [SerializeField] GameObject _finishPannel;
    [SerializeField] GameObject[] _otherUI;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "FinishCollider")
        {
            FinishGame();
        }
    }

    private void FinishGame()
    {
        foreach (GameObject ui in _otherUI)
        {
            ui.SetActive(false);
        }

        _finishPannel.SetActive(true);

        Time.timeScale = 0f;
    }
}
