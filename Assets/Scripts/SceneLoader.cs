using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private string sceneName;

    [ContextMenu(nameof(Test))]
    private void Test()
    {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
    }
    
    private void Test2()
    {
        SceneManager.UnloadSceneAsync(sceneName);
    }
}
