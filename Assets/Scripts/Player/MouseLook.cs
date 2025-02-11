using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public Vector2 mouseSensitivity = new Vector2(100, 100);
    public Transform parent;

    PlayerManager playerManager;
    private PlayerControls playerControls;
    private Vector2 mouseLook;
    private float xRotation = 0f;
    

    private void Awake()
    {
        parent = transform.parent;
        playerManager = parent.GetComponent<PlayerManager>();
        playerControls = new PlayerControls();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void FixedUpdate()
    {
        Look();
    }

    private void Look()
    {
        mouseLook = playerControls.Controls.Look.ReadValue<Vector2>();

        float mouseX = mouseLook.x * mouseSensitivity.x * Time.deltaTime;
        float mouseY = mouseLook.y * mouseSensitivity.y * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90);

        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        parent.Rotate(Vector3.up * mouseX);
    }
    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }
}
