using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
    public void Restart()
    {
        Time.timeScale = 1f; // возвращаем время в норму
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // перезапуск текущей сцены
    }
}
