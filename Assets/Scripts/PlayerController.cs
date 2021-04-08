using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float acceleration = 2.0f;
    public float deceleration = 2.0f;
    public float maximumWalkVelocity = 0.5f;
    public float maximumRunVelocity = 2.0f;

    float velocityX = 0;
    float velocityZ = 0;
    int velocityXHash;
    int velocityZHash;
    Animator animator;
    CharacterController controller;

    void ProcessMovementInputs(bool isMovingForward, bool isMovingBackward, bool isMovingLeft, bool isMovingRight, bool isRunning)
    {
        // set the max velocity depending on whether the character is running or walking
        float currentMaxVelocity = isRunning ? maximumRunVelocity : maximumWalkVelocity;

        if (isMovingForward)
        {
            // if the forward velocity is above max, then decelerate
            if (velocityZ > currentMaxVelocity)
            {
                velocityZ -= deceleration * Time.deltaTime;
            }
            // otherwise accelerate until velocity reaches max
            else
            {
                velocityZ += acceleration * Time.deltaTime;
                velocityZ = Mathf.Min(velocityZ, currentMaxVelocity);
            }
        }

        if (isMovingBackward && velocityZ > -currentMaxVelocity)
        {
            velocityZ -= acceleration * Time.deltaTime;
        }

        if (isMovingLeft && velocityX > -currentMaxVelocity)
        {
            velocityX -= acceleration * Time.deltaTime;
        }

        if (isMovingRight && velocityX < currentMaxVelocity)
        {
            velocityX += acceleration * Time.deltaTime;
        }

        // if the character is not moving forward, but forward velocity is above 0, then decelerate
        if (!isMovingForward && velocityZ > 0)
        {
            velocityZ -= deceleration * Time.deltaTime;
            velocityZ = Mathf.Max(0, velocityZ);
        }

        // if the character is not moving backward, but forward velocity is below 0, then decelerate
        if (!isMovingBackward && velocityZ < 0)
        {
            velocityZ += deceleration * Time.deltaTime;
            velocityZ = Mathf.Min(velocityZ, 0);
        }

        // if the character is not moving left, but horizontal velocity is below 0, then decelerate
        if (!isMovingLeft && velocityX < 0)
        {
            velocityX += deceleration * Time.deltaTime;
            velocityX = Mathf.Min(velocityX, 0);
        }

        // if the character is not moving right, but horizontal velocity is above 0, then decelerate
        if (!isMovingRight && velocityX > 0)
        {
            velocityX -= deceleration * Time.deltaTime;
            velocityX = Mathf.Max(0, velocityX);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();

        velocityXHash = Animator.StringToHash("VelocityX");
        velocityZHash = Animator.StringToHash("VelocityZ");
    }

    // Update is called once per frame
    void Update()
    {
        bool isMovingForward = Input.GetKey(KeyCode.W);
        bool isMovingBackward = Input.GetKey(KeyCode.S);
        bool isMovingLeft = Input.GetKey(KeyCode.A);
        bool isMovingRight = Input.GetKey(KeyCode.D);
        bool isRunning = Input.GetKey(KeyCode.LeftShift);

        ProcessMovementInputs(isMovingForward, isMovingBackward, isMovingLeft, isMovingRight, isRunning);

        // set the animation blend parameters
        animator.SetFloat(velocityXHash, velocityX);
        animator.SetFloat(velocityZHash, velocityZ);
    }
}
