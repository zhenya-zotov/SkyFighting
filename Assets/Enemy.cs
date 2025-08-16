using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
public class Enemy : MonoBehaviour
{
    [Header("Destroyed Enemy")]
    public GameObject destroyedEnemy;

    public float speed = 2f;
    public float damagePlanet = 10f;

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
            // найдём компонент здоровья у планеты
            var ph = col.gameObject.GetComponent<PlanetHealth>();
            if (ph != null)
            {
                ph.TakeDamage(damagePlanet); // урон за одного врага (подбери значение)
            }
            DieEmeny();
        }
    }
    
    // TODO: Error Some objects were not cleaned up when closing the scene.
    // void OnDestroy()
    // {
    //     var destroyed = Instantiate(destroyedEnemy, gameObject.transform.position, Quaternion.identity);
    //     destroyed.transform.localScale = gameObject.transform.localScale;

    //     Destroy(gameObject);
    // }

    void DieEmeny()
    {
        if (destroyedEnemy != null)
        {
            var destroyed = Instantiate(destroyedEnemy, transform.position, Quaternion.identity);
            destroyed.transform.localScale = transform.localScale;
        }

        Destroy(gameObject); // уничтожаем врага
    }

}
