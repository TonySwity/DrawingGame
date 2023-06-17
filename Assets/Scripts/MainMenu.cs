using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject _mainMenu;

    private readonly int _firstScene = 1;

    public void Play()
    {
        SceneManager.LoadScene(_firstScene);
    }
}
