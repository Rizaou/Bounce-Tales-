using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Collector : MonoBehaviour
{
    [SerializeField] TMP_Text _scoreText;
    [SerializeField] int score = 0;

    private void Awake()
    {
        _scoreText.text = "SCORE: 0";
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Collectable")
        {
            Collect();
            Destroy(other.gameObject);
        }
    }



    public void Collect()
    {
        score++;
        UpdateText();
    }

    public void UpdateText()
    {
        _scoreText.text = "SCORE: " + score;
    }
}
