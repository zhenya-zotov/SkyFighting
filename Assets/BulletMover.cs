using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BulletMover : MonoBehaviour
{
    public float speed = 12f;

    public enum ForwardAxis { Up, Right }
    [Tooltip("Какая ось у префаба считается направлением 'вперёд'")]
    public ForwardAxis forwardAxis = ForwardAxis.Up;

    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f; // на всякий случай
    }

    void OnEnable()
    {
        // сбросим текущую скорость (на случай реюза пулей из пула)
        rb.linearVelocity = Vector2.zero;

        Vector2 dir = forwardAxis == ForwardAxis.Up
            ? (Vector2)transform.up
            : (Vector2)transform.right;

        rb.linearVelocity = dir * speed;
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}