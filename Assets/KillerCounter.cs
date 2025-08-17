using TMPro;
using UnityEngine;

public class KillerCounter : MonoBehaviour
{
    public static KillerCounter Instance; // Singleton
    public TMP_Text killerCointText;
    private int killer = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        Instance = this; 
    }

    public void AddKill(int amount)
    {
        killer += amount;
        UpdateUI();
    }


    private void UpdateUI()
    {
        killerCointText.text = $"Count killer: {killer}";
    }
}
