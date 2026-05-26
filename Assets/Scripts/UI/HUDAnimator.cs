using UnityEngine;

public class HUDAnimator : MonoBehaviour
{
    public RectTransform healthBar;

    public RectTransform energyBar;

    void Update()
    {
        float pulse =
            Mathf.Sin(Time.time * 4f) * 0.02f;

        healthBar.localScale =
            Vector3.one * (1f + pulse);

        energyBar.localScale =
            Vector3.one * (1f + pulse);
    }
}
