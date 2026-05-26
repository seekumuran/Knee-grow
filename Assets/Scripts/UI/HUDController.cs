using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour
{
    public Slider healthBar;

    public Slider energyBar;

    public PlayerStats playerStats;

    void Update()
    {
        healthBar.value =
            playerStats.currentHealth;

        energyBar.value =
            playerStats.currentEnergy;
    }
}
