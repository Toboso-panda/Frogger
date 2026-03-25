using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMng : MonoBehaviour
{
    public void GoBackToMenu()
    {
        SceneManager.LoadSceneAsync("MainMenu");
    }
}
