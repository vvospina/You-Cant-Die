using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform player;     // Referencia al jugador
    public float speed = 2f;     // Velocidad de movimiento
    public float patrolSpeed = 1f;
    public float shotDistance = 5f;
    public float followDistance = 10f;

    private Vector2 patrolPointA;
    private Vector2 patrolPointB;
    private bool goingToA = true;

    public enum EnemyState
    {
        patrol,
        follow,
        shoot
    }

    private EnemyState state = EnemyState.patrol;

    private void Start()
    {
        // Puntos para patrullar (ajústalos como quieras)
        patrolPointA = new Vector2(transform.position.x - 2, transform.position.y);
        patrolPointB = new Vector2(transform.position.x + 2, transform.position.y);
    }

    private void Update()
    {
        UpdateState();
        UpdateBehaviour();
    }

    private void UpdateBehaviour()
    {
        switch (state)
        {
            case EnemyState.patrol:
                Patrol();
                break;

            case EnemyState.follow:
                FollowPlayer();
                break;

            case EnemyState.shoot:
                ShootPlayer();
                break;
        }
    }

    private void UpdateState()
    {
        float distance = Vector2.Distance(transform.position, player.position);

        if (distance < shotDistance)
        {
            state = EnemyState.shoot;
        }
        else if (distance < followDistance)
        {
            state = EnemyState.follow;
        }
        else
        {
            state = EnemyState.patrol;
        }
    }

    // ----------- BEHAVIOURS -------------

    private void Patrol()
    {
        Vector2 target = goingToA ? patrolPointA : patrolPointB;

        transform.position = Vector2.MoveTowards(transform.position, target, patrolSpeed * Time.deltaTime);

        if (Vector2.Distance(transform.position, target) < 0.1f)
            goingToA = !goingToA;

        FlipSprite(target.x);
    }

    private void FollowPlayer()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        FlipSprite(player.position.x);
    }

    private void ShootPlayer()
    {
        // Aquí pones tu código para disparar
        Debug.Log("Disparando al jugador!");
        FlipSprite(player.position.x);
    }

    // Voltear sprite automáticamente
    private void FlipSprite(float targetX)
    {
        if (targetX > transform.position.x)
            transform.localScale = new Vector3(1, 1, 1);
        else
            transform.localScale = new Vector3(-1, 1, 1);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            LevelManager.Instance.PlayerDied();
        }
    }
}

