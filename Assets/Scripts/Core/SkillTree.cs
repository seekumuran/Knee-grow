using UnityEngine;

public class SkillTree : MonoBehaviour
{
    public bool unlockedHeavyAttack;

    public bool unlockedDoubleDash;

    public bool unlockedEnergyBurst;

    public void UnlockHeavyAttack()
    {
        unlockedHeavyAttack = true;
    }

    public void UnlockDoubleDash()
    {
        unlockedDoubleDash = true;
    }

    public void UnlockEnergyBurst()
    {
        unlockedEnergyBurst = true;
    }
}
