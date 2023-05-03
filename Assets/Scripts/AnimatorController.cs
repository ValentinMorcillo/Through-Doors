using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    private Animator animator;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        AirSpeed();
    }

    public void AirSpeed()
    {
        //Set AirSpeed in animator
        animator.SetFloat("AirSpeedY", rb.velocity.y);
    }

    public void OnGround(bool isGrounded)
    {
        animator.SetBool("Grounded", isGrounded);
    }

    public void Jump()
    {
        animator.SetTrigger("Jump");
        //animator.SetBool("Grounded", isGrounded);
    }

    public void CanClimb(bool canClimb)
    {
        animator.SetBool("CanClimb", canClimb);
    }

    public void Run()
    {
        animator.SetInteger("AnimState", 1);
    }

    public void Idle()
    {
        animator.SetInteger("AnimState", 0);
    }
}
