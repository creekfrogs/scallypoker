using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    PlayerControls playerControls;

    [Header("Movement")]
    public float moveSpeed;


    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
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
        GetInput();
        PlayerMovement();
    }

    private void GetInput()
    {
        horizontalInput = playerControls.Controls.Movement.ReadValue<Vector2>().x;
        verticalInput = playerControls.Controls.Movement.ReadValue<Vector2>().y;
    }

    private void PlayerMovement()
    {
        moveDirection = transform.forward * verticalInput + transform.right * horizontalInput;

        rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
    }
}
