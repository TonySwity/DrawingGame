using System;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private GameObject _soundOnButton;
    [SerializeField] private GameObject _soundOffButton;
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
            Destroy(this);
        }
    }

    private void Start()
    {
        _soundOnButton.SetActive(false);
    }

    public void OnMusic()
    {
        _music.Play();
        _soundOffButton.SetActive(true);
        _soundOnButton.SetActive(false);
    }

    public void OffMusic()
    {
        _music.Pause();
        _soundOnButton.SetActive(true);
        _soundOffButton.SetActive(false);
    }
}
