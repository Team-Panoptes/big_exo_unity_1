using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    //public InputActions actions;

    public InputActionAsset actions;
    public float speed = 1f;
    private InputAction xAxis;

    void Awake()
    {
        xAxis = actions.FindActionMap("CubeActionsMap").FindAction("XAxis");
    }

    void OnEnable()
    {
        actions.FindActionMap("CubeActionsMap").Enable();
    }

    void OnDisable()
    {
        actions.FindActionMap("CubeActionsMap").Disable();
    }

    void Update()
    {
        MoveX();
        AutoMove();
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
