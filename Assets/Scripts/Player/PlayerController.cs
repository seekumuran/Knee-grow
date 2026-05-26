using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 6f;
    public float rotationSpeed = 12f;
    public float gravity = -20f;

    [Header("Dash")]
    public float dashSpeed = 20f;
    public float dashDuration = 0.2f;
    public float dashCooldown = 0.5f;

    [Header("References")]
    public Transform cameraTransform;
    public Animator animator;

    private CharacterController controller;

    private Vector3 velocity;
    private Vector3 moveDirection;

    private bool isDashing;
    private bool canDash = true;

    private float dashTimer;
    private float dashCooldownTimer;

    private readonly int moveHash = Animator.StringToHash("MoveSpeed");
    private readonly int dashHash = Animator.StringToHash("Dash");

    void Start()
    {
        controller = GetComponent<CharacterController>();

        if (cameraTransform == null)
        {
            cameraTransform = Camera.main.transform;
        }
    }

    void Update()
    {
        HandleMovement();
        HandleGravity();
        HandleDashCooldown();
        UpdateAnimations();
    }

    void HandleMovement()
    {
        if (isDashing)
        {
            DashMovement();
            return;
        }

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 inputDirection = new Vector3(horizontal, 0f, vertical).normalized;

        if (inputDirection.magnitude >= 0.1f)
        {
            Vector3 camForward = cameraTransform.forward;
            Vector3 camRight = cameraTransform.right;

            camForward.y = 0f;
            camRight.y = 0f;

            camForward.Normalize();
            camRight.Normalize();

            moveDirection =
                camForward * inputDirection.z +
                camRight * inputDirection.x;

            controller.Move(moveDirection * moveSpeed * Time.deltaTime);

            Quaternion targetRotation =
                Quaternion.LookRotation(moveDirection);

            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                targetRotation,
                rotationSpeed * Time.deltaTime
            );
        }

        HandleDashInput();
    }

    void HandleGravity()
    {
        if (controller.isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }

    void HandleDashInput()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {
            StartDash();
        }
    }

    void StartDash()
    {
        isDashing = true;
        canDash = false;

        dashTimer = dashDuration;
        dashCooldownTimer = dashCooldown;

        if (animator != null)
        {
            animator.SetTrigger(dashHash);
        }
    }

    void DashMovement()
    {
        controller.Move(
            moveDirection * dashSpeed * Time.deltaTime
        );

        dashTimer -= Time.deltaTime;

        if (dashTimer <= 0f)
        {
            isDashing = false;
        }
    }

    void HandleDashCooldown()
    {
        if (!canDash)
        {
            dashCooldownTimer -= Time.deltaTime;

            if (dashCooldownTimer <= 0f)
            {
                canDash = true;
            }
        }
    }

    void UpdateAnimations()
    {
        if (animator == null) return;

        Vector3 horizontalVelocity = controller.velocity;
        horizontalVelocity.y = 0f;

        float speed = horizontalVelocity.magnitude;

        animator.SetFloat(moveHash, speed);
    }

    public bool IsDashing()
    {
        return isDashing;
    }

    public Vector3 GetMoveDirection()
    {
        return moveDirection;
    }
}
