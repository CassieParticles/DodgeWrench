using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float playerMoveSpeed = 15.0f;

    private PlayerInput playerInput;
    private Rigidbody2D rigidbodyComp;

    private Vector2 moveVector;

    // Start is called before the first frame update
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        rigidbodyComp = GetComponent<Rigidbody2D>();   

        //Add the "Move" function to the callback for the "Move" Input action
        playerInput.actions["Move"].performed += Move;
        playerInput.actions["Move"].canceled += Move;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void Move(InputAction.CallbackContext context)
    {
        moveVector = context.ReadValue<Vector2>();
        rigidbodyComp.velocity = moveVector * playerMoveSpeed;
    }
}
