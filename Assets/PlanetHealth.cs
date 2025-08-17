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

    public GameObject gameOverPanel;

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
            GameOver();
        }
    }

    void GameOver()
    {
        // показать панель
        gameOverPanel.SetActive(true);

        // остановить игру
        Time.timeScale = 0f;
    }

    public float HP01() => Mathf.Clamp01(hp / maxHP);
}
