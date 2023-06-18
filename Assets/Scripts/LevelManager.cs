using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private GameObject _nextLevelPanel;
    [SerializeField] private GameObject _gamePanel;
    [SerializeField] private TextMeshProUGUI _textNextButtonPanel;
    
    private Player _player;
    private readonly int _secondScene = 2;
    private int _finishLevel = 5;
    
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
        if (SceneManager.GetActiveScene().buildIndex == _finishLevel)
        {
            _textNextButtonPanel.text = "CONGRATULATION YOU BIG BAD WOLF";
        }
        _nextLevelPanel.SetActive(true);
    }

    public void NextLevel()
    {
        int nextLevelIndex = SceneManager.GetActiveScene().buildIndex + 1;
        
        if (nextLevelIndex > SceneManager.sceneCountInBuildSettings - 1)
        {
            nextLevelIndex = _secondScene;
            SceneManager.LoadScene(nextLevelIndex);
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
