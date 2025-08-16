using UnityEngine;
using TMPro;
using Unity.Collections;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; } // singleton

    [Header("Timer")]
    public float roundTime = 30f;
    public TMP_Text timerText;
    float timeLeft;

    [Header("Enemy Damage")]
    public float damageInocrease = 5f;  // прибавка урока

    [Header("Level")]
    public TMP_Text levelCountText;
    private int levelCount = 0;

    void Awake()
    {
        Instance = this;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timeLeft = roundTime;
        UpdateTimerUI();
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0f)
        {
            NextRound();
        }
        UpdateTimerUI();
    }

    void NextRound()
    {
        timeLeft = roundTime;

        levelCount += 1;

        levelCountText.text = "LEVEL: " + levelCount;

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject enemyObj in enemies)
        {
            Enemy enemy = enemyObj.GetComponent<Enemy>();

            if (enemy != null)
            {
                enemy.damagePlanet += damageInocrease;
            }
        }
    }

    void UpdateTimerUI()
    {
        if (!timerText) return;
        int s = Mathf.CeilToInt(timeLeft);
        timerText.text = s.ToString();
    }

}
