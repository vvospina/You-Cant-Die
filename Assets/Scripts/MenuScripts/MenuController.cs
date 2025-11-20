using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuController : MonoBehaviour
{
    public void PlayGame()
    {
        Debug.Log("PlayGame() fue llamado correctamente.");
        SceneManager.LoadScene("Nivel1");
    }

    public void GoHome()
    {
        Debug.Log("GoHome() fue llamado correctamente.");
        SceneManager.LoadScene("Home");
    }

    public void QuitGame()
    {
        Debug.Log("QuitGame() fue llamado correctamente.");
        Application.Quit();
    }
}