using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public static MusicPlayer instance;

    [SerializeField] GameObject _musicPrefab;
    [SerializeField] GameObject _createdMusic = null;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);

    }

    public void CreateMusicPlayer()
    {
        if (GameObject.FindWithTag("Music")) { return; }

        _createdMusic = Instantiate(_musicPrefab, null);

        DontDestroyOnLoad(_createdMusic);
    }
}
