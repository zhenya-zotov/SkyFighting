using TMPro;
using UnityEngine;

public class SkyCoinCounter : MonoBehaviour
{
    public static SkyCoinCounter Instance; // Singleton
    public TMP_Text skyCoinText;
    private int skyCoins = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        Instance = this; 
    }

    public void AddCoin(int amount)
    {
        skyCoins += amount;
        UpdateUI();
    }

    public int GetCoins()
    {
        return skyCoins;
    }

    public bool TryToConsumeCoins(int amount)
    {
        if (skyCoins < amount)
        {
            return false;
        }
        skyCoins -= amount;
        UpdateUI();
        return true;
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

    private void UpdateUI()
    {
        skyCoinText.text = $"SCORE: {kFormat(skyCoins)}";
    }
}
