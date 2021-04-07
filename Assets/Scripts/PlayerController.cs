using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float acceleration = 2.0f;
    public float deceleration = 2.0f;
    public float maximumWalkVelocity = 0.5f;
    public float maximumRunVelocity = 2.0f;

    Animator animator;
    float velocityX = 0;
    float velocityZ = 0;
    int velocityXHash;
    int velocityZHash;

    void Decelerate()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        velocityXHash = Animator.StringToHash("VelocityX");
        velocityZHash = Animator.StringToHash("VelocityZ");
    }

    // Update is called once per frame
    void Update()
    {
        bool isMovingForward = Input.GetKey(KeyCode.W);
        bool isMovinBackward = Input.GetKey(KeyCode.S);
        bool isMovingLeft = Input.GetKey(KeyCode.A);
        bool isMovingRight = Input.GetKey(KeyCode.D);
        bool isRunning = Input.GetKey(KeyCode.LeftShift);

        float currentMaxVelocity = isRunning ? maximumRunVelocity : maximumWalkVelocity;

        if (isMovingForward && velocityZ < currentMaxVelocity)
        {
            velocityZ += acceleration * Time.deltaTime;
        }

        if (isMovingLeft && velocityX > -currentMaxVelocity)
        {
            velocityX -= acceleration * Time.deltaTime;
        }

        if (isMovingRight && velocityX < currentMaxVelocity)
        {
            velocityX += acceleration * Time.deltaTime;
        }

        animator.SetFloat(velocityXHash, velocityX);
        animator.SetFloat(velocityZHash, velocityZ);
    }
}
