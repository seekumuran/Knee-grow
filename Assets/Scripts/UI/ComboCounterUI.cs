using UnityEngine;
using TMPro;

public class ComboCounterUI : MonoBehaviour
{
    public TextMeshProUGUI comboText;

    private int combo;

    private float comboTimer;

    public float resetTime = 2f;

    void Update()
    {
        comboTimer -= Time.deltaTime;

        if (comboTimer <= 0)
        {
            combo = 0;

            comboText.text = "";
        }
    }

    public void AddHit()
    {
        combo++;

        comboTimer = resetTime;

        comboText.text =
            combo.ToString() + " HIT COMBO";
    }
}
