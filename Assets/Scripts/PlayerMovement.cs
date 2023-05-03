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

    [HideInInspector] public bool ledgeDetected;

    [Header("Ledge info")]
    [SerializeField] private Vector3 offset1;
    [SerializeField] private Vector3 offset2;

    private Vector3 climbBegunPosition;
    private Vector3 climbOverPosition;

    private bool canGrabLedge = true;
    private bool canClimb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, 0.1f, groundMask);

        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        CheckForLedge();
    }

    private void CheckForLedge()
    {
        if (ledgeDetected && canGrabLedge)
        {
            canGrabLedge = false;

            Vector3 ledgePosition = GetComponentInChildren<LedgeDetection>().transform.position;

            climbBegunPosition = ledgePosition + offset1;
            climbOverPosition = ledgePosition + offset2;

            canClimb = true;
        }

        if (canClimb)
        {
            transform.position = climbBegunPosition;
            Invoke(nameof(LedgeClimbOver), .3f); //Esta funcion hay que llamarla al final de la animacion con un animation event
        }
    }

    private void LedgeClimbOver()
    {
        canClimb = false;
        transform.position = climbOverPosition;
        Invoke(nameof(AllowLedgeClimb), .1f);
    }

    private void AllowLedgeClimb() => canGrabLedge = true;

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");

        movement = new Vector3(moveHorizontal, 0f, moveVertical).normalized;

        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(groundCheck.position, 0.1f);
    }
}
