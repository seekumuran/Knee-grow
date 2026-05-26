using UnityEngine;

public class AchievementSystem : MonoBehaviour
{
    public bool firstKill;

    public bool comboMaster;

    public void UnlockFirstKill()
    {
        firstKill = true;
    }

    public void UnlockComboMaster()
    {
        comboMaster = true;
    }
}
