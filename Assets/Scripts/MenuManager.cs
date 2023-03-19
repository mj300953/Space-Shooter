using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private Button loadLevelButton;
    [SerializeField] private Button quitButton;
    [SerializeField] private string levelName;

    private void Awake()
    {
        loadLevelButton.onClick.AddListener(LoadLevel);
        loadLevelButton.onClick.AddListener(QuitGame);
    }

    private void LoadLevel()
    {
        SceneManager.LoadScene(levelName);
    }
    
    private void QuitGame()
    {
        Application.Quit();
    }
}
 