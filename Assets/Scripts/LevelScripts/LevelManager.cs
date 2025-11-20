using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void PlayerDied()
    {
        SceneManager.LoadScene("GameOver");
        Time.timeScale = 1f;
    }

    public void PlayerWin()
    {
        SceneManager.LoadScene("Victory");
        Time.timeScale = 1f;
    }
}

