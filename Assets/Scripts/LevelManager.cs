using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private GameObject _nextLevelPanel;
    [SerializeField] private GameObject _gamePanel;
    
    private Player _player;
    private readonly int _firstScene = 1;
    public static LevelManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this);
        }
    }
    private void Start()
    {
        _gamePanel.SetActive(true);
        _nextLevelPanel.SetActive(false);
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
        _player = FindObjectOfType<Player>();
    }
    
    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void SetPlayer(Player player)
    {
        _player = player;
        _player.Finished += Activate;
    }
}
