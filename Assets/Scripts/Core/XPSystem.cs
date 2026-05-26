using UnityEngine;

public class XPSystem : MonoBehaviour
{
    public int currentLevel = 1;

    public int currentXP;

    public int xpToNextLevel = 100;

    public void AddXP(int amount)
    {
        currentXP += amount;

        if (currentXP >= xpToNextLevel)
        {
            LevelUp();
        }
    }

    void LevelUp()
    {
        currentLevel++;

        currentXP = 0;

        xpToNextLevel += 50;

        Debug.Log("LEVEL UP");
    }
}
