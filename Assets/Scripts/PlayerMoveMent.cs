using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveMent : MonoBehaviour
{
    public float moveSpeed = 2.0f; // Speed of movement
    public float rotationSpeed = 100.0f; // Speed of rotation

    private Rigidbody2D myRigidBody;
    private float currentRotation = 0f;

    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        // Get horizontal and vertical input values and calculate the movement direction
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector2 moveDirection = new Vector2(horizontalInput, verticalInput).normalized;

        // Calculate rotation angle based on the movement direction
        float targetRotation = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;

        if (moveDirection != Vector2.zero)
        {
            myRigidBody.velocity = moveDirection * moveSpeed;
            currentRotation = targetRotation;
        }
        else
        {
            myRigidBody.velocity = Vector2.zero;
        }

        myRigidBody.rotation = currentRotation;
    }
}
