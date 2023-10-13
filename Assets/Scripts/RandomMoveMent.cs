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
    [Header("Wobbling/scale")]
    [SerializeField] float scaleSpeed = 1.0f; // Speed of the scaling
    [SerializeField] float targetScale = 2.0f; // Target scale factor
    [SerializeField] float originalScale = 1.0f; // Original scale factor

    private bool isScalingUp = true;
    float moveSpeed;
    float changeDirectionInterval;
    float timer;
    Vector2 randomDirection;
    Rigidbody2D myRigidBody;

    float scaleGrower;
    void Start()
    {
        moveSpeed = Random.Range(minMoveSpeed, maxMoveSpeed);
        changeDirectionInterval = Random.Range(minTimeChangeDirection, maxTimeChangeDirection);
        timer = changeDirectionInterval;
        SetRandomDirection();

        // Get the Rigidbody2D component
        myRigidBody = GetComponent<Rigidbody2D>();
    }



    void Update()
    {

    }

    void MakeScale()
    {
        //Scale
        Vector2 currentScale = new Vector2(transform.localScale.x, transform.localScale.y);

        if (isScalingUp)
        {
            // Scale up
            currentScale += Vector2.one * scaleSpeed * Time.deltaTime;

            if (currentScale.x >= targetScale)
            {
                currentScale = Vector2.one * targetScale;
                isScalingUp = false;
            }
        }
        else
        {
            // Scale down
            currentScale -= Vector2.one * scaleSpeed * Time.deltaTime;

            if (currentScale.x <= originalScale)
            {
                currentScale = Vector2.one * originalScale;
                isScalingUp = true;
            }
        }

        transform.localScale = new Vector3(currentScale.x, currentScale.y, 1.0f);
    }

    void FixedUpdate()
    {
        MakeScale();

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
