using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private GameObject _nextLevelPanel;

    private void Start()
    {
        _nextLevelPanel.SetActive(false);
    }

    public void Activate()
    {
        _nextLevelPanel.SetActive(true);
    }

    public void NextLevel()
    {
        GameManager.Instance.CurrentLevel++;
        
        if (GameManager.Instance.CurrentLevel > 5)
        {
            SceneManager.LoadScene(0);
        }
        
        SceneManager.LoadScene(GameManager.Instance.CurrentLevel);
        
        _nextLevelPanel.SetActive(false);
    }
}
