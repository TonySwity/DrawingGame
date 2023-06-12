using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource _music;
    
    private bool _isSoundOn = true;
    
    public static SoundManager Instance;
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    public void OnOffMusic()
    {
        _isSoundOn = !_isSoundOn;
        
        if (_isSoundOn)
        {
            _music.Play();
        }
        else
        {
            _music.Pause();
        }
        
    }
}
