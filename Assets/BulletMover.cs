using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BulletMover : MonoBehaviour
{
    public float speed = 12f;
    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnEnable()
    {
        rb.linearVelocity = transform.up * speed;
        rb.gravityScale = 0f; // на всякий случай
    }
}