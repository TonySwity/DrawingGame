using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int CurrentLevel = 1;
    
    [SerializeField] private GameObject _mainMenu;
    [SerializeField] private GameObject _gamePanel;
    
    public static GameManager Instance;

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

    private void Start()
    {
        _gamePanel.SetActive(false);
    }

    public void Play()
    {
        _mainMenu.SetActive(false);
        _gamePanel.SetActive(true);
        SceneManager.LoadScene(1);
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
