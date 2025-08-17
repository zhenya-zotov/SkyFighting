using UnityEngine;

public class AutoFire : MonoBehaviour
{
    public Transform firePoint;       // точка выстрела (child у Tank)
    public GameObject bulletPrefab;   // префаб пули
    public float fireRate = 6f;       // выстрелов в секунду
    public int bulletsCont = 1;
    public float bulletsAngle = 5f;

    float cooldown;

    void Update()
    {
        if (!firePoint || !bulletPrefab) return;

        cooldown -= Time.deltaTime;
        if (cooldown <= 0f)
        {
            FireBullets();
            cooldown = 1f / Mathf.Max(0.001f, fireRate);
        }
    }
    
    void FireBullets()
    {
        if (bulletsCont <= 1)
        {
            // если одна пуля — просто прямо
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            return;
        }

        var spreadAngle = bulletsAngle * bulletsCont;
        // угол между пулями
        float angleStep = spreadAngle / (bulletsCont - 1);
        // начальный угол, чтобы веер был симметричный
        float startAngle = -spreadAngle / 2f;

        for (int i = 0; i < bulletsCont; i++)
        {
            float angle = startAngle + i * angleStep;
            Quaternion rot = firePoint.rotation * Quaternion.Euler(0f, 0f, angle);
            Instantiate(bulletPrefab, firePoint.position, rot);
        }
    }
}
