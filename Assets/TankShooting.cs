using UnityEngine;

public class TankShooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireCooldown = 0.15f;
    private float timer;

    void Update()
    {
        timer -= Time.deltaTime;
        if (Input.GetKey(KeyCode.Space) && timer <= 0f)
        {
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation); // БЕЗ parent
            timer = fireCooldown;
        }
    }
}
