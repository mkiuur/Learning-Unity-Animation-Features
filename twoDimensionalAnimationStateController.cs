using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class twoDimensionalAnimationStateController : MonoBehaviour
{
    Animator animator;
    float velocityX = 0.0f;
    float velocityZ = 0.0f;
    int VelocityXHash;
    int VelocityZHash;
    public float acceleration = 2.0f;
    public float decceleration = 2.0f;
    public float maxWalkVelocity = 0.5f;
    public float maxRunVelocity = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        // search the game object this script is attached to and get animator component
        animator = GetComponent<Animator>();
        VelocityXHash = Animator.StringToHash("Velocity X");
        VelocityZHash = Animator.StringToHash("Velocity Z");
    }

    // Update is called once per frame
    void Update()
    {
        // input will be true or false depending on if the player is pressing the passed in key parameter
        // get key input from player
        bool forwardPressed = Input.GetKey(KeyCode.W);
        bool leftPressed = Input.GetKey(KeyCode.A);
        bool rightPressed = Input.GetKey(KeyCode.D);
        bool runPressed = Input.GetKey(KeyCode.LeftShift);

        // set current max velocity
        float currentMaxVelocity = runPressed ? maxRunVelocity : maxWalkVelocity;

        // handle changes in velocity
        changeVelocity(forwardPressed,leftPressed,rightPressed,runPressed,currentMaxVelocity);
        lockOrResetVelocity(forwardPressed,leftPressed,rightPressed,runPressed,currentMaxVelocity);

        animator.SetFloat(VelocityZHash,velocityZ);
        animator.SetFloat(VelocityXHash,velocityX);
    }

    // handles acceleration and decceleration
    void changeVelocity(bool forwardPressed, bool leftPressed, bool rightPressed, bool runPressed, float currentMaxVelocity)
    {
        // increase velocity in forward direction
        if(forwardPressed && velocityZ < currentMaxVelocity)
        {
            velocityZ += Time.deltaTime * acceleration;
        }

        // increase velocity in left direction
        if(leftPressed && velocityX > -currentMaxVelocity)
        {
            velocityX -= Time.deltaTime * acceleration;
        }

        // increase velocity in right direction
        if(rightPressed && velocityX < currentMaxVelocity)
        { 
            velocityX += Time.deltaTime * acceleration;
        }

        // deccelerate in forward direction
        if(!forwardPressed && velocityZ > 0.0f)
        {
            velocityZ -= Time.deltaTime * decceleration;
        }

        // reset velocityZ
        if(!forwardPressed && velocityZ < 0.0f)
        {
            velocityZ = 0.0f;
        }

        // deccelerate in left direction
        if(!leftPressed && velocityX < 0.0f)
        {
            velocityX += Time.deltaTime * decceleration;
        }

        // deccelerate in right direction
        if(!rightPressed && velocityX > 0.0f)
        {
            velocityX -= Time.deltaTime * decceleration;
        }

        // reset velocityX 
        if(!leftPressed && !rightPressed && velocityX !=0.0f && (velocityX > -0.05f && velocityX < 0.05f))
        {
            velocityX = 0.0f;
        }
    }

    void lockOrResetVelocity(bool forwardPressed, bool leftPressed, bool rightPressed, bool runPressed, float currentMaxVelocity)
    {
        // lock forward
        if(forwardPressed && runPressed && velocityZ > currentMaxVelocity)
        {
            velocityZ = currentMaxVelocity;
        }
        //deccelerate to maximumm walk velocity
        else if(forwardPressed && velocityZ > currentMaxVelocity)
        {
            velocityZ -= Time.deltaTime * decceleration;
            // round to current max velocity if within threshold
            if(velocityZ > currentMaxVelocity && velocityZ < (currentMaxVelocity + 0.05f))
            {
                velocityZ = currentMaxVelocity;
            }
        }
        // round to current max velocity if within threshold
        else if(forwardPressed && velocityZ < currentMaxVelocity && velocityZ > (currentMaxVelocity - 0.05f))
        {
            velocityZ = currentMaxVelocity;
        }

        // lock left
        if(leftPressed && runPressed && velocityX < -currentMaxVelocity)
        {
            velocityX = -currentMaxVelocity;
        }
        //deccelerate to maximumm walk velocity
        else if(leftPressed && velocityX < -currentMaxVelocity)
        {
            velocityX += Time.deltaTime * decceleration;
            // round to current max velocity if within threshold
            if(velocityX < -currentMaxVelocity && velocityX > (-currentMaxVelocity - 0.05f))
            {
                velocityX = -currentMaxVelocity;
            }
        }
        // round to current max velocity if within threshold
        else if(leftPressed && velocityX > -currentMaxVelocity && velocityX < (-currentMaxVelocity + 0.05f))
        {
            velocityX = -currentMaxVelocity;
        }

        // lock right
        if(rightPressed && runPressed && velocityX > currentMaxVelocity)
        {
            velocityX = currentMaxVelocity;
        }
        //deccelerate to maximumm walk velocity
        else if(rightPressed && velocityX > currentMaxVelocity)
        {
            velocityX -= Time.deltaTime * decceleration;
            // round to current max velocity if within threshold
            if(velocityX > currentMaxVelocity && velocityX < (currentMaxVelocity + 0.05f))
            {
                velocityX = currentMaxVelocity;
            }
        }
        // round to current max velocity if within threshold
        else if(rightPressed && velocityX < currentMaxVelocity && velocityX > (currentMaxVelocity - 0.05f))
        {
            velocityX = currentMaxVelocity;
        }
    }
}
