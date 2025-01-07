using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        Invoke("Load", 0.5f);
    }

    public void QuitGame()
    {
        Invoke("Quit", 0.5f);
    }

    void Load()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    void Quit()
    {
        Application.Quit();

    }
}