using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public Transform target;

    [Header("Mouse Settings")]
    public float mouseSensitivity = 120f;

    [Header("Camera Settings")]
    public float distance = 6f;
    public float height = 2f;
    public float smoothSpeed = 10f;

    [Header("Clamp")]
    public float minPitch = -30f;
    public float maxPitch = 60f;

    private float yaw;
    private float pitch;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        yaw = transform.eulerAngles.y;
        pitch = transform.eulerAngles.x;
    }

    void LateUpdate()
    {
        if (target == null) return;

        yaw += Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        pitch -= Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        pitch = Mathf.Clamp(pitch, minPitch, maxPitch);

        Quaternion rotation = Quaternion.Euler(pitch, yaw, 0f);

        Vector3 desiredPosition =
            target.position
            - (rotation * Vector3.forward * distance)
            + Vector3.up * height;

        transform.position = Vector3.Lerp(
            transform.position,
            desiredPosition,
            smoothSpeed * Time.deltaTime
        );

        transform.LookAt(target.position + Vector3.up * 1.5f);
    }
}
