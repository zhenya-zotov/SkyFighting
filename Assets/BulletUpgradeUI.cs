using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BulletUpgradeUI : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private AutoFire autoFire;
    [SerializeField] private Button addBulletsButton;
    [SerializeField] private TMP_Text addBulletsButtonText;
    [SerializeField] private Button addDPSButton;
    [SerializeField] private TMP_Text addDPSButtonText;
    [SerializeField] private SkyCoinCounter skyCoinCounter;

    [Header("Settings")]
    [SerializeField] private int addBulletsPrice = 30; 
    [SerializeField] private int addBulletsCount = 2;   
    [SerializeField] private int addDPSPrice = 30;
    [SerializeField] private float addDPS = 0.7f; 

    private void Awake()
    {
        if (addBulletsButton) addBulletsButton.onClick.AddListener(OnAddBullets);
        if (addDPSButton) addDPSButton.onClick.AddListener(OnAddDPS);
        if (addBulletsButtonText)
        {
            addBulletsButtonText.text = $"Bullets {kFormat(addBulletsPrice)}";
        }
        if (addDPSButtonText)
        {
            addDPSButtonText.text = $"DPS {kFormat(addDPSPrice)}";
        }
    }

    private string kFormat(int value)
    {
        string kSuff = "";
        while (value >= 1000)
        {
            value /= 1000;
            kSuff += "k";
        }

        return $"{value}{kSuff}";
    }

    private void OnAddBullets()
    {
        if (!autoFire || !skyCoinCounter) return;

        if (!skyCoinCounter.TryToConsumeCoins(addBulletsPrice)) return;
        
        int newCount = autoFire.bulletsCont + addBulletsCount;

        autoFire.bulletsCont = newCount;
        addBulletsPrice += addBulletsPrice;
        if (addBulletsPrice > 500 && addBulletsPrice < 1000)
        {
            addBulletsPrice = 500;
        }
        if (addBulletsButtonText)
        {
            addBulletsButtonText.text = $"Bullets {kFormat(addBulletsPrice)}";
        }
    }
    
    private void OnAddDPS()
    {
        if (!autoFire || !skyCoinCounter) return;
        
        if (!skyCoinCounter.TryToConsumeCoins(addDPSPrice)) return;

        var newCount = autoFire.fireRate + addDPS;

        autoFire.fireRate = newCount;

        addDPSPrice += addDPSPrice;
        if (addDPSPrice > 500 && addDPSPrice < 1000)
        {
            addDPSPrice = 500;
        }
        if (addDPSButtonText)
        {
            addDPSButtonText.text = $"DPS {kFormat(addDPSPrice)}";
        }
    }
}