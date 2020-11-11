using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationStateControllerTurn : MonoBehaviour
{
    Animator animator;
    float velocityX = 0.0f;
    float velocityZ = 0.0f;
    // public float accelerationX = 0.5f;
    // public float accelerationZ = 0.5f;
    // public float deccelerationX = 0.5f;
    // public float deccelerationZ = 0.5f;
    [SerializeField]
    private float accelerationX = 2.0f;
    public float accelerationZ = 2.0f;
    public float deccelerationX = 2.0f;
    public float deccelerationZ = 2.0f;
    int VelocityXHash;
    int VelocityZHash;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        VelocityXHash = Animator.StringToHash("Velocity X");
        VelocityZHash = Animator.StringToHash("Velocity Z");
    }

    // Update is called once per frame
    void Update()
    {
        bool forwardPressed = Input.GetKey("w");
        bool leftPressed = Input.GetKey("a");
        bool rightPressed = Input.GetKey("d");
        // bool runPressed = Input.GetKey("left shift");
        if(forwardPressed && velocityZ < 2.0f)
        {
            velocityZ += Time.deltaTime * accelerationZ;
        }
        if(!forwardPressed && velocityZ > 0.0f)
        {
            velocityZ -= Time.deltaTime * deccelerationZ;
        }
        if(!forwardPressed && velocityZ < 0.0f)
        {
            velocityZ = 0.0f;
        }
        if(forwardPressed && velocityZ > 2.0f)
        {
            velocityZ = 2.0f;
        }
        if(leftPressed && velocityX > -2.0f)
        {
            velocityX -= Time.deltaTime * accelerationX;
        }
        if(!leftPressed && velocityX < 0.0f)
        {
            velocityX += Time.deltaTime * deccelerationX;
        }
        if(rightPressed && velocityX < 2.0f)
        {
            velocityX += Time.deltaTime * accelerationX;
        }
        if(!rightPressed && velocityX > 0.0f)
        {
            velocityX -= Time.deltaTime * deccelerationX;
        }
        if(leftPressed && velocityX < -2.0f)
        {
            velocityX = -2.0f;
        }
        if(rightPressed && velocityX > 2.0f){
            velocityX = 2.0f;
        }
        animator.SetFloat(VelocityZHash,velocityZ);
        animator.SetFloat(VelocityXHash,velocityX);
    }
}
