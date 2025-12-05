using UnityEngine;

public class SimpleCameraController : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public float moveSpeed = 5f;

    float xRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        HandleLook();
        HandleMovement();
    }

    void HandleLook()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.parent.Rotate(Vector3.up * mouseX);
    }

    void HandleMovement()
    {
        float x = Input.GetAxis("Horizontal");   // A / D
        float z = Input.GetAxis("Vertical");     // W / S

        Vector3 move = transform.parent.forward * z + transform.parent.right * x;

        transform.parent.position += move * moveSpeed * Time.deltaTime;
    }
}
