using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    public XPSystem xpSystem;

    void Start()
    {
        LoadGame();
    }

    public void SaveGame()
    {
        PlayerPrefs.SetInt(
            "Level",
            xpSystem.currentLevel
        );

        PlayerPrefs.SetInt(
            "XP",
            xpSystem.currentXP
        );

        PlayerPrefs.Save();
    }

    public void LoadGame()
    {
        xpSystem.currentLevel =
            PlayerPrefs.GetInt("Level", 1);

        xpSystem.currentXP =
            PlayerPrefs.GetInt("XP", 0);
    }
}
