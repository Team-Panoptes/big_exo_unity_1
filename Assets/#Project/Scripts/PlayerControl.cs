using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class PlayerControl : MonoBehaviour
{

    //public InputActions actions;

    public InputActionAsset actions;
    public float speed = 1f;
    public float jumpForce = 500f;
    private InputAction xAxis;
    private Rigidbody rb;

    private bool isJumping;

    void Awake()
    {
        xAxis = actions.FindActionMap("CubeActionsMap").FindAction("XAxis");
        rb = GetComponent<Rigidbody>();
    }

    void OnEnable()
    {
        actions.FindActionMap("CubeActionsMap").Enable();
        actions.FindActionMap("CubeActionsMap").FindAction("Jump").performed += OnJump;
    }

    void OnDisable()
    {
        actions.FindActionMap("CubeActionsMap").Disable();
        actions.FindActionMap("CubeActionsMap").FindAction("Jump").performed -= OnJump;
    }

    void Update()
    {
        MoveX();
        AutoMove();
    }

    private void OnJump(InputAction.CallbackContext context)
    {
        if (!isJumping)
        {
            rb.AddForce(Vector3.up * jumpForce);
            isJumping = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Ground"))
        {
            isJumping = false;
        }
    }

    private void MoveX()
    {
        float xMove = xAxis.ReadValue<float>();
        transform.position += speed * Time.deltaTime * xMove * transform.right;
    }

    private void AutoMove()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }
}
