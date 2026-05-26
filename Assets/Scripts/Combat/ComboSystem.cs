using UnityEngine;

public class ComboSystem : MonoBehaviour
{
    [Header("Combo")]
    public float comboResetTime = 1f;

    [Header("Animator")]
    public Animator animator;

    private int comboStep;

    private float comboTimer;

    private readonly int comboHash =
        Animator.StringToHash("ComboStep");

    void Update()
    {
        HandleComboInput();
        HandleComboReset();
    }

    void HandleComboInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            comboStep++;

            if (comboStep > 3)
            {
                comboStep = 1;
            }

            comboTimer = comboResetTime;

            animator.SetInteger(comboHash, comboStep);
        }
    }

    void HandleComboReset()
    {
        comboTimer -= Time.deltaTime;

        if (comboTimer <= 0f)
        {
            comboStep = 0;

            animator.SetInteger(comboHash, 0);
        }
    }
}
