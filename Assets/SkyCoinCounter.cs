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

    private void UpdateUI()
    {
        skyCoinText.text = "SCORE: " + skyCoins;
    }
}
