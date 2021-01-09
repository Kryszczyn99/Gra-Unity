using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController2D controller;
    public Animator animator;
    
    static float horizontalMove = 0f;
    static public float runSpeed = 15f;
    bool jump = false;
    bool crouch = false;
    static bool freeze = false;

    // Update is called once per frame
    void Update()
    {
        if(!freeze) horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
        if(!freeze)
        {
            if (Input.GetButtonDown("Jump"))
            {
                jump = true;
                animator.SetBool("IsJumping", true);
            }
        }
           
    }
 
    public void OnLanding ()
    {
        animator.SetBool("IsJumping", false);
    }

    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }
    static public void Freeze()
    {
        freeze = true;
        horizontalMove = 0f;
    }
    static public void UnFreeze()
    {
        freeze = false;
    }
    static public bool IsFreeze()
    {
        return freeze;
    }
}
