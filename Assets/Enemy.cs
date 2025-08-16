using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
public class Enemy : MonoBehaviour
{
    public float speed = 2f;

    private Transform planet;
    private Rigidbody2D rb;

    void Start()
    {
        planet = GameObject.FindGameObjectWithTag("Planet")?.transform;
        rb = GetComponent<Rigidbody2D>();

        // базовые безопасные настройки
        rb.gravityScale = 0f;                  // чтобы не "падал"
        rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        if (planet == null) Debug.LogError("Enemy: не найден объект с тегом Planet");
    }

    void FixedUpdate()
    {
        if (!planet) return;

        // направление к центру планеты
        Vector2 dir = ((Vector2)planet.position - rb.position).normalized;

        // движение через физику (корректно для Dynamic/Kinematic)
        rb.MovePosition(rb.position + dir * speed * Time.fixedDeltaTime);

        // повернуть лицом к планете (необязательно)
        rb.rotation = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Planet"))
        {
            // TODO: вызвать PlanetHealth.TakeDamage(...)
            Destroy(gameObject);
        }
    }
}
