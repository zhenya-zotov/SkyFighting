using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private EnemySpawner enemySpawner;
    [SerializeField] private AutoFire autoFire;
    [SerializeField] private Button addBulletsButton;
    [SerializeField] private Button addDPSButton;
    [SerializeField] private SkyCoinCounter skyCoinCounter;
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private Slider xpSlider;
    public static GameManager Instance { get; private set; } // singleton

    [Header("Upgrades")]
    [SerializeField] private int addBulletsCount = 2;
    [SerializeField] private float addDPS = 0.7f; 
    
    [Header("Timer")]
    public float roundTime = 30f;
    public TMP_Text timerText;
    float timeLeft;

    [Header("Enemy Damage")]
    public float damageInocrease = 5f;  // прибавка урока
    public float spawnRateMultiplayer = 2;

    [Header("Level")]
    public TMP_Text levelCountText;
    private int levelCount = 0;
    [SerializeField] private int scoreToNextLevel = 2; 
    [SerializeField] private float growScoreToNextLevel = 2f; 
    private int lastLevelUpScore = 0; 
    
    private bool isPaused = false;

    void Awake()
    {
        if (addBulletsButton) addBulletsButton.onClick.AddListener(OnAddBullets);
        if (addDPSButton) addDPSButton.onClick.AddListener(OnAddDPS);
        Instance = this;
        lastLevelUpScore = 0;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timeLeft = roundTime;
        UpdateTimerUI();
    }
    
    private void OnAddBullets()
    {
        if (!autoFire) return;
        
        int newCount = autoFire.bulletsCont + addBulletsCount;

        autoFire.bulletsCont = newCount;
        TogglePause();
    }
    
    private void OnAddDPS()
    {
        if (!autoFire) return;
        
        var newCount = autoFire.fireRate + addDPS;

        autoFire.fireRate = newCount;
        TogglePause();
    }

    // Update is called once per frame
    void Update()
    {
        var score = skyCoinCounter.GetCoins();
        xpSlider.value = ((float)score - lastLevelUpScore) / (scoreToNextLevel - lastLevelUpScore);
        if (skyCoinCounter.GetCoins() >= scoreToNextLevel)
        {
            lastLevelUpScore = scoreToNextLevel;
            scoreToNextLevel = Mathf.CeilToInt(scoreToNextLevel * growScoreToNextLevel);
            NextRound();
        }
    }

    void NextRound()
    {
        if (isPaused) return;
        xpSlider.value = 0;
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
        enemySpawner.SetLevel(levelCount);
        enemySpawner.spawnInterval = enemySpawner.spawnInterval * (1/spawnRateMultiplayer);
        TogglePause();
    }
    
    public void TogglePause()
    {
        if (isPaused)
        {
            Time.timeScale = 1f; // снимаем паузу
            pausePanel.SetActive(false);
            isPaused = false;
        }
        else
        {
            Time.timeScale = 0f; // ставим игру на паузу
            pausePanel.SetActive(true);
            isPaused = true;
        }
    }

    void UpdateTimerUI()
    {
        if (!timerText) return;
        int s = Mathf.CeilToInt(timeLeft);
        timerText.text = s.ToString();
    }

}
