using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 2;
    public float deceleration = 2;

    Animator animator;
    float velocityX = 0;
    float velocityZ = 0;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        bool moveForward = Input.GetKey("w");
        bool moveBackward = Input.GetKey("s");
        bool moveLeft = Input.GetKey("a");
        bool moveRight = Input.GetKey("d");
        bool isRunning = Input.GetKey("left shift");

        if (moveForward)
        {
            velocityZ += moveSpeed * Time.deltaTime;
        }

        if (moveLeft)
        {
            velocityX -= moveSpeed * Time.deltaTime;
        }

        if (moveRight)
        {
            velocityX += moveSpeed * Time.deltaTime;
        }

        animator.SetFloat("VelocityX", velocityX);
        animator.SetFloat("VelocityZ", velocityZ);
    }
}
