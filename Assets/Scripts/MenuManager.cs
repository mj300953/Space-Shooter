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
        quitButton.onClick.AddListener(QuitGame);
    }

    private void LoadLevel()
    {
        SceneManager.LoadScene(levelName);
    }
    
    private void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit");
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
    }
    
    public void ResumeGame()
    {
        Time.timeScale = 1f;
    }
}
 