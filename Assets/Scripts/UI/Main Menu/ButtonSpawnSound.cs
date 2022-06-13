using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSpawnSound : MonoBehaviour
{
    [SerializeField] private GameObject buttonSpawnSound;

    public void PlayButtonSpawnSound()
    {
        if (!buttonSpawnSound)
        {
            Debug.LogWarning("Button ses efekti yok!");
            return;
        }
        
        GameObject sound = Instantiate(buttonSpawnSound, null);
        Destroy(sound, 3f);
    }
}
