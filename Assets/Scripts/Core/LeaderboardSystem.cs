using UnityEngine;

public class LeaderboardSystem : MonoBehaviour
{
    public int highScore;

    public void SaveScore(int score)
    {
        if (score > highScore)
        {
            highScore = score;

            PlayerPrefs.SetInt(
                "HighScore",
                highScore
            );
        }
    }

    void Start()
    {
        highScore =
            PlayerPrefs.GetInt(
                "HighScore",
                0
            );
    }
}
