using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationStateController : MonoBehaviour
{

    Animator animator_;
    int isWalkingHash;
    int isRunningHash;

    // Start is called before the first frame update
    void Start()
    {
        animator_ = GetComponent<Animator>();
        Debug.Log(animator_); 
        isWalkingHash = Animator.StringToHash("isWalking");
        isRunningHash = Animator.StringToHash("isRunning");
    }

    // Update is called once per frame
    void Update()
    {
        bool isWalking = animator_.GetBool(isWalkingHash);
        bool isRunning = animator_.GetBool(isRunningHash);
        bool wPressed = Input.GetKey("w");
        bool shiftPressed = Input.GetKey("left shift");
        if(!isWalking && wPressed){
            animator_.SetBool(isWalkingHash,true);
        }
        if(isWalking && !wPressed){
            animator_.SetBool(isWalkingHash,false);
        }
        if(!isRunning && (wPressed && shiftPressed)){
            animator_.SetBool(isRunningHash,true);
        }
        if(isRunning && (!wPressed || !shiftPressed)){
            animator_.SetBool(isRunningHash,false);
        }
    }
}
