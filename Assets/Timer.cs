using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    // Update is called once per frame
    [SerializeField] TextMeshProUGUI timerText;
    float elapsedTime;

    void Update()
    {
        elapsedTime += Time.deltaTime;
        timerText.text = elapsedTime.ToString();
    }
}
