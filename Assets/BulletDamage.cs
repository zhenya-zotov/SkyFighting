using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class BulletDamage : MonoBehaviour
{
    public float damage = 1f;

    void OnTriggerEnter2D(Collider2D other)
    {
        // ищем компонент здоровья у того, во что попали
        var target = other.GetComponent<EnemyHealth>();
        if (target != null)
        {
            var destroyed = target.TakeDamage(damage);
            var enemy = other.gameObject.GetComponent<Enemy>();
            if (destroyed)
            {
                enemy.DieEmeny();
            }
            Destroy(gameObject);
        }
    }
}
