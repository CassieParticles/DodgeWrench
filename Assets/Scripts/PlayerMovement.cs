using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float maxSpeed = 10.0f;
    [SerializeField] float accTime = 0.2f;
    [SerializeField] float damageAccTime = 0.0f;

    private PlayerInput playerInput;
    private Rigidbody2D rigidbodyComp;

    private Vector2 moveVector;

    private Vector2 smoothVelDir;
    private Vector2 currentAccDir;

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
        smoothVelDir = Vector2.SmoothDamp(smoothVelDir, moveVector, ref currentAccDir, accTime + damageAccTime);

        rigidbodyComp.velocity = new Vector3(smoothVelDir.x, smoothVelDir.y) * maxSpeed;
    }

    private void Move(InputAction.CallbackContext context)
    {
        moveVector = context.ReadValue<Vector2>();
        //rigidbodyComp.velocity = moveVector * playerMoveSpeed;
    }
}
