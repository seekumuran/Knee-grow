using UnityEngine;
using TMPro;

public class CombatRankSystem : MonoBehaviour
{
    public TextMeshProUGUI rankText;

    private int comboScore;

    private string currentRank = "D";

    public void AddCombatScore(int amount)
    {
        comboScore += amount;

        UpdateRank();
    }

    void UpdateRank()
    {
        if (comboScore > 100)
        {
            currentRank = "S";
        }
        else if (comboScore > 75)
        {
            currentRank = "A";
        }
        else if (comboScore > 50)
        {
            currentRank = "B";
        }
        else if (comboScore > 25)
        {
            currentRank = "C";
        }
        else
        {
            currentRank = "D";
        }

        rankText.text =
            "RANK : " + currentRank;
    }
}
