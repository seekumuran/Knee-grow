using UnityEngine;

public class ParrySystem : MonoBehaviour
{
    public bool isParrying;

    public float parryWindow = 0.25f;

    private float parryTimer;

    void Update()
    {
        HandleParryInput();

        UpdateParryWindow();
    }

    void HandleParryInput()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            StartParry();
        }
    }

    void StartParry()
    {
        isParrying = true;

        parryTimer = parryWindow;
    }

    void UpdateParryWindow()
    {
        if (!isParrying) return;

        parryTimer -= Time.deltaTime;

        if (parryTimer <= 0)
        {
            isParrying = false;
        }
    }

    public bool SuccessfulParry()
    {
        return isParrying;
    }
}
