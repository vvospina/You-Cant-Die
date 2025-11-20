using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryChecker : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene("Nivel2");
        }

        if (collision.CompareTag("Finish"))
        {
            LevelManager.Instance.PlayerWin();
        }
    }
}
