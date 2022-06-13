using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameOverTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        GameObject player = GameObject.FindWithTag("Player");
        player.GetComponent<Rigidbody>().useGravity = false;
        SceneManager.LoadScene(1);
        Debug.LogError("Game Over");
    }
}
