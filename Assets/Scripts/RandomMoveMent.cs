using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMoveMent : MonoBehaviour
{
    [SerializeField] float minMoveSpeed = 4f; // Speed at which the object moves
    [SerializeField] float maxMoveSpeed = 10f; // Speed at which the object moves
    [SerializeField] float minTimeChangeDirection = 2.0f; // Minimum time to change direction
    [SerializeField] float maxTimeChangeDirection = 10f;  // Maximume time to change direction
    [SerializeField] float rotationSpeed = 30f;

    private bool isScalingUp = true;
    private float moveSpeed;
    float changeDirectionInterval;
    float timer;
    Vector2 randomDirection;
    Rigidbody2D myRigidBody;

    void Start()
    {
        moveSpeed = Random.Range(minMoveSpeed, maxMoveSpeed);
        changeDirectionInterval = Random.Range(minTimeChangeDirection, maxTimeChangeDirection);
        timer = changeDirectionInterval;
        SetRandomDirection();

        // Get the Rigidbody2D component
        myRigidBody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        // Update the timer
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            // Change direction and reset the timer
            SetRandomDirection();
            timer = changeDirectionInterval;
        }

        myRigidBody.angularVelocity = rotationSpeed;

        // Set velocity for smooth movement
        Vector2 velocity = randomDirection * moveSpeed;
        myRigidBody.velocity = new Vector2(velocity.x, velocity.y);
    }

    void SetRandomDirection()
    {
        // Generate a random direction
        randomDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
    }
}
