using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private GameObject _nextLevelPanel;
    [SerializeField] private Player _player;

    private readonly int _firstScene = 1;
    private void Start()
    {
        _nextLevelPanel.SetActive(false);
    }

    private void OnEnable()
    {
        _player.Finished += Activate;
    }

    private void OnDisable()
    {
        _player.Finished -= Activate;
    }

    private void Activate()
    {
        _nextLevelPanel.SetActive(true);
    }

    public void NextLevel()
    {
        int nextLevelIndex = SceneManager.GetActiveScene().buildIndex + 1;
        
        if (nextLevelIndex > SceneManager.sceneCountInBuildSettings - 1)
        {
            SceneManager.LoadScene(_firstScene);
        }
        SceneManager.LoadScene(nextLevelIndex);
        
        _nextLevelPanel.SetActive(false);
    }
}
