using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    [SerializeField] private GameObject _mainMenu;
    [SerializeField] private GameObject _gamePanel;
    private readonly int _firstScene = 1;
    
    public static SceneSwitcher Instance;

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
        _gamePanel.SetActive(false);
    }

    public void Play()
    {
        _mainMenu.SetActive(false);
        _gamePanel.SetActive(true);
        SceneManager.LoadScene(_firstScene);
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
