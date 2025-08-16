using UnityEngine;

public class OrbitByMouse : MonoBehaviour
{
    public Transform planet;              // центр
    public float radius = 3f;             // фиксированный радиус орбиты
    public float angularSpeedDeg = 360f;  // макс. угловая скорость (°/сек)

    Camera cam;

    void Awake() => cam = Camera.main;

    void Start()
    {
        // Инициализируем позицию ровно на окружности
        if (planet)
        {
            Vector2 fromCenter = (Vector2)(transform.position - planet.position);
            if (fromCenter.sqrMagnitude < 0.0001f) fromCenter = Vector2.right;
            Vector2 pos = fromCenter.normalized * radius;
            transform.position = planet.position + (Vector3)pos;
            transform.up = pos.normalized; // наружу
        }
    }

    void Update()
    {
        if (!planet || !cam) return;

        // Куда указала мышь (в мире)
        Vector3 m = cam.ScreenToWorldPoint(Input.mousePosition);
        m.z = 0f;

        // Текущий и целевой углы относительно центра
        Vector2 fromCenter = (Vector2)(transform.position - planet.position);
        float cur = Mathf.Atan2(fromCenter.y, fromCenter.x) * Mathf.Rad2Deg;
        Vector2 toMouse = (Vector2)(m - planet.position);
        if (toMouse.sqrMagnitude < 1e-6f) return; // курсор почти на центре
        float target = Mathf.Atan2(toMouse.y, toMouse.x) * Mathf.Rad2Deg;

        // Плавно поворачиваемся по кратчайшему пути с ограничением скорости
        float next = Mathf.MoveTowardsAngle(cur, target, angularSpeedDeg * Time.deltaTime);

        // Выставляем позицию СТРОГО на окружность радиуса radius
        float rad = next * Mathf.Deg2Rad;
        Vector2 orbitPos = new Vector2(Mathf.Cos(rad), Mathf.Sin(rad)) * radius;
        transform.position = planet.position + (Vector3)orbitPos;

        // Смотрим наружу
        transform.up = orbitPos.normalized;
    }
}