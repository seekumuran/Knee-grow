using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverPanel;

    public PlayerStats playerStats;

    private bool gameOver;

    void Update()
    {
        if (gameOver) return;

        if (playerStats.currentHealth <= 0)
        {
            TriggerGameOver();
        }
    }

    void TriggerGameOver()
    {
        gameOver = true;

        Time.timeScale = 0f;

        gameOverPanel.SetActive(true);
    }
}
