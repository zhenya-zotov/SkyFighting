using UnityEngine;

public class TankController : MonoBehaviour
{
    public Transform planet;
    public float orbitSpeed = 50f;

    // Update is called once per frame
    void Update()
    {
        // крутим вокруг планеты
        transform.RotateAround(planet.position, Vector3.forward, orbitSpeed * Time.deltaTime);

        // Всегда смотрим наружу от центра
        Vector3 dir = transform.position - planet.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle - 90);
    }
}
