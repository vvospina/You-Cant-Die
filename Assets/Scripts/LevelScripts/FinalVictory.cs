using UnityEngine;

public class FinalVictory : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
            LevelManager.Instance.PlayerWin();
        }
    }
}
