using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;

    private Rigidbody rb;
    private Vector3 movement;

    public Transform groundCheck;
    private bool isGrounded;

    public float jumpForce = 10f;

    public LayerMask groundMask;

    AnimatorController animator;

    [HideInInspector] public bool ledgeDetected;

    [Header("Climbing info")]
    [SerializeField] private Vector3 offset1;
    [SerializeField] private Vector3 offset2;
    [SerializeField] private float climbingAnimationDuration;


    bool lookingRight = true;

    private Vector3 climbBegunPosition;
    private Vector3 climbOverPosition;

    private bool canGrabLedge = true;
    private bool isClimbing;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<AnimatorController>();
    }

    private void Update()
    {
        CheckIsGrounded();
        CheckIfRunning();
        CheckForLedge();
        CheckLookRotation();

        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    void FixedUpdate()
    {
        if (!isClimbing && canGrabLedge)
        {
            float moveHorizontal = Input.GetAxisRaw("Horizontal");
            float moveVertical = Input.GetAxisRaw("Vertical");

            movement = new Vector3(moveHorizontal, 0f, moveVertical).normalized;

            rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
        }
    }

    void CheckLookRotation()
    {
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
            lookingRight = true;
        }

        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.rotation = new Quaternion(0f, 180f, 0f, 0f);
            lookingRight = false;
        }
    }

    void CheckIfRunning()
    {
        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            Run();
        }
        else
        {
            Idle();
        }
    }

    void Idle()
    {
        animator.Idle();
    }

    void Run()
    {
        animator.Run();
    }

    void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        animator.Jump();
    }

    private void CheckIsGrounded()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, 0.1f, groundMask);
        animator.OnGround(isGrounded);
    }

    private void CheckForLedge()
    {
        if (ledgeDetected && canGrabLedge)
        {
            canGrabLedge = false;

            Vector3 ledgePosition = GetComponentInChildren<LedgeDetection>().transform.position;

            Vector3 auxOffset1 = offset1;
            Vector3 auxOffset2 = offset2;

            if (!lookingRight)
            {
                auxOffset1.x = -offset1.x;
                auxOffset2.x = -offset2.x;
            }
            else
            {
                auxOffset1 = offset1;
                auxOffset2 = offset2;
            }

            climbBegunPosition = ledgePosition + auxOffset1;
            climbOverPosition = ledgePosition + auxOffset2;

            isClimbing = true;
        }

        if (isClimbing && !canGrabLedge)
        {
            transform.position = climbBegunPosition;
            animator.CanClimb(isClimbing);
            isClimbing = false;
            rb.isKinematic = true;
            Invoke(nameof(LedgeClimbOver), climbingAnimationDuration); //Esta funcion hay que llamarla al final de la animacion con un animation event, representa que termina de hacer el climbeo
        }
    }

    private void LedgeClimbOver()
    {
        Debug.Log(rb.isKinematic);
        rb.isKinematic = false;
        transform.position = climbOverPosition;
        animator.CanClimb(isClimbing);
        animator.Run();
        Invoke(nameof(AllowLedgeClimb), .25f);
    }

    private void AllowLedgeClimb() => canGrabLedge = true;


    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(groundCheck.position, 0.1f);
    }
}
