using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 5f;

    private Rigidbody rb;
    private Vector3 lookDirection;
    private Vector2 movement;
    private bool mouse = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        mouse = GetComponent<PlayerInput>().currentControlScheme == "Keyboard";
    }

    // Update is called once per frame
    void Update()
    {
        if(lookDirection != Vector3.zero)
        {
            rb.MoveRotation(Quaternion.LookRotation(lookDirection));
        }
        rb.MovePosition(rb.position + new Vector3(movement.x, 0f, movement.y) * Time.deltaTime * movementSpeed);
    }

    private void FixedUpdate()
    {
        //rb.AddForce(new Vector3(movement.x, 0f, movement.y), ForceMode.VelocityChange);
    }

    public void Move(InputAction.CallbackContext context)
    {
        movement = context.ReadValue<Vector2>();
    }

    public void Aim(InputAction.CallbackContext context)
    {
        if (context.phase != InputActionPhase.Canceled)
        {
            Vector2 contextValue = context.ReadValue<Vector2>();
            lookDirection = new Vector3(contextValue.x, 0f, contextValue.y);
            if (mouse)
            {
                lookDirection = Camera.main.ScreenToWorldPoint(contextValue);
                lookDirection -= Camera.main.transform.position;

                lookDirection.y = 0f;
                lookDirection.Normalize();
            }
        }
    }

    public void DeviceChanged(PlayerInput input) 
    {
        mouse = input.currentControlScheme == "Keyboard";
    }
}
