using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pausePanel;

    public void PauseGame()
    {
        Time.timeScale = 0f;
        pausePanel.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        pausePanel.SetActive(false);
    }

    public void GoHome()
    {
        Time.timeScale = 1f;
        UnityEngine.SceneManagement.SceneManager.LoadScene("Home");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit Game");
    }
}


