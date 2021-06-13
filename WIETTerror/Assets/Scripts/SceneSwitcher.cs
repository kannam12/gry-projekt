using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Scenes/SampleScene");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
