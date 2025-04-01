using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement; // 要加這個才能切換場景

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] float remainingTime;
    [SerializeField] GameObject gameOverPanel; // 拖曳 GameOverPanel 進來

    void Update()
    {
        if (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
        }
        else if (remainingTime <= 0)
        {
            remainingTime = 0;
            GameOver();
        }

        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void GameOver()
    {
        gameOverPanel.SetActive(true); // 顯示 Game Over 畫面
        StartCoroutine(ReturnToMainMenu()); // 延遲幾秒後回到主選單
    }

    IEnumerator ReturnToMainMenu()
    {
        yield return new WaitForSeconds(3); // 等 3 秒
        SceneManager.LoadScene("MainMenu"); // 換成你的主選單場景名稱
    }
}

