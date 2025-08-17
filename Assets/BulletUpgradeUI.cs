using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BulletUpgradeUI : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private AutoFire autoFire;
    [SerializeField] private Button addBulletsButton;
    [SerializeField] private Button addDPSButton;
    [SerializeField] private SkyCoinCounter skyCoinCounter;

    [Header("Settings")]
    [SerializeField] private int addBulletsPrice = 30; 
    [SerializeField] private int addBulletsCount = 2;   
    [SerializeField] private int addDPSPrice = 30;
    [SerializeField] private float addDPS = 0.7f; 
    [SerializeField] private float addDPSCostChange = 2f; 
    [SerializeField] private float addBulletsCostChange = 2f; 

    private void Awake()
    {
        if (addBulletsButton) addBulletsButton.onClick.AddListener(OnAddBullets);
        if (addDPSButton) addDPSButton.onClick.AddListener(OnAddDPS);
    }
    

    private void OnAddBullets()
    {
        if (!autoFire || !skyCoinCounter) return;

        if (!skyCoinCounter.TryToConsumeCoins(addBulletsPrice)) return;
        
        int newCount = autoFire.bulletsCont + addBulletsCount;

        autoFire.bulletsCont = newCount;
        ChangeCostUpgrade();
    }
    
    private void OnAddDPS()
    {
        if (!autoFire || !skyCoinCounter) return;
        
        if (!skyCoinCounter.TryToConsumeCoins(addDPSPrice)) return;

        var newCount = autoFire.fireRate + addDPS;

        autoFire.fireRate = newCount;

        ChangeCostUpgrade();
    }

    void ChangeCostUpgrade()
    {
        addDPSPrice = Mathf.RoundToInt(addDPSPrice * addDPSCostChange);
        addBulletsPrice = Mathf.RoundToInt(addBulletsPrice * addBulletsCostChange);
    }
}