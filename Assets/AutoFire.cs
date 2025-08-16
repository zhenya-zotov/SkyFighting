using UnityEngine;

public class AutoFire : MonoBehaviour
{
    public Transform firePoint;       // точка выстрела (child у Tank)
    public GameObject bulletPrefab;   // префаб пули
    public float fireRate = 6f;       // выстрелов в секунду

    float cooldown;

    void Update()
    {
        if (!firePoint || !bulletPrefab) return;

        cooldown -= Time.deltaTime;
        if (cooldown <= 0f)
        {
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation); // без parent!
            cooldown = 1f / Mathf.Max(0.001f, fireRate);
        }
    }
}
