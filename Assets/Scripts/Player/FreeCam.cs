using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeCam : MonoBehaviour
{
    PlayerControls playerControls;
    public Vector3 moveInput;
    public Vector3 mouseInput;
    public float camSpeed = 4;
    public float sensitivity = 50;

    private void Awake()
    {
        playerControls = new PlayerControls();
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

    private void Update()
    {
        moveInput = new Vector3(playerControls.Controls.Movement.ReadValue<Vector2>().x, 0, 
            playerControls.Controls.Movement.ReadValue<Vector2>().y);
        mouseInput = new Vector3(-playerControls.Controls.Look.ReadValue<Vector2>().y,
            playerControls.Controls.Look.ReadValue<Vector2>().x, 0);

        if (Input.GetMouseButton(1))
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            transform.Translate(moveInput * camSpeed * Time.deltaTime);
            Rotation();
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    void Rotation()
    {
        transform.Rotate(mouseInput * sensitivity * Time.deltaTime);
        Vector3 eulerRotation = transform.rotation.eulerAngles;
        transform.rotation = Quaternion.Euler(eulerRotation.x, eulerRotation.y, 0);
    }
}
