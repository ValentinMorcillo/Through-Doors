using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSController : MonoBehaviour
{
    [SerializeField] Transform characterBase;
    private Rigidbody rb;
    AudioManagerWhiteRoom amWhiteRoom;
    AudioManager am;

    [SerializeField] Camera cam;


    [SerializeField] float speed = 5f;
    [SerializeField] float jumpForce = 28f;
    [SerializeField] bool isWhiteRoom = true;


    private float nextFootstepTime;
    [SerializeField] float footstepInterval = 0.6f;
    public float maxVelocityChange = 10f;

    private bool isGrounded;

    void Start()
    {
        am = AudioManager.Get();
        amWhiteRoom = AudioManagerWhiteRoom.Get();

        rb = GetComponent<Rigidbody>();
        nextFootstepTime = 0f;

       // Physics.gravity = new Vector3(0, -90f, 0);
    }

    private void Update()
    {
        CheckIsGrounded();

        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = cam.transform.forward * moveVertical + cam.transform.right * moveHorizontal;
        movement.y = 0;
        movement.Normalize();

        rb.velocity = movement * speed;

        if (isGrounded)
        {
            if (Time.time >= nextFootstepTime && (movement.x != 0f || movement.z != 0f))
            {
                PlayFootstepSound();
                nextFootstepTime = Time.time + footstepInterval;
            }
        }
    }

    void Jump()
    {
        rb.velocity = Vector3.up * jumpForce;
       // rb.AddForce(0f, jumpForce, 0f, ForceMode.VelocityChange);
    }

    private void CheckIsGrounded()
    {
        isGrounded = Physics.Raycast(characterBase.position + Vector3.up * 0.1f, Vector3.down, out RaycastHit hit, 0.2f);
    }

    void PlayFootstepSound()
    {
        if (isWhiteRoom)
        {
            if (amWhiteRoom != null)
            {
                amWhiteRoom.PlayFootstepsWhiteRoomSound();
            }
        }
        else
        {
            if (am != null)
            {
                am.PlayFootstepsSound();
            }
        }
    }
}