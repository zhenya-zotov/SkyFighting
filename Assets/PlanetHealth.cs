using UnityEngine;
using UnityEngine.SceneManagement;

public class PlanetHealth : MonoBehaviour
{
    [Header("HP")]
    public float maxHP = 100f;
    [SerializeField] private float hp;

    [Header("On Death")]
    public bool reloadSceneOnDeath = true;
    public string sceneName = ""; // пусто = текущая сцена

    void Awake()
    {
        hp = maxHP;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void TakeDamage(float dmg)
    {
        if (hp <= 0f) return;
        hp = Mathf.Max(0f, hp - dmg);

        // тут можно дергать UI обновление (если есть)
        // PlanetUI.Instance?.SetHP01(hp / maxHP);

        if (hp <= 0f)
        {
            if (reloadSceneOnDeath)
            {
                var name = string.IsNullOrEmpty(sceneName)
                    ? SceneManager.GetActiveScene().name
                    : sceneName;
                SceneManager.LoadScene(name);
            }
            else
            {
                // можно показать окно поражения
                Debug.Log("Планета уничтожена");
            }
        }
    }

    public float HP01() => Mathf.Clamp01(hp / maxHP);
}
