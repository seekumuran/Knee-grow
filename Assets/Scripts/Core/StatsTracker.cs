using UnityEngine;

public class StatsTracker : MonoBehaviour
{
    public int enemiesKilled;

    public int totalDamage;

    public int highestCombo;

    public void AddKill()
    {
        enemiesKilled++;
    }

    public void AddDamage(int amount)
    {
        totalDamage += amount;
    }

    public void SetHighestCombo(int combo)
    {
        if (combo > highestCombo)
        {
            highestCombo = combo;
        }
    }
}
