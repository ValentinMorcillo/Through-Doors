using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSController : MonoBehaviour
{
    [SerializeField] Transform characterBase;
    private Rigidbody rb;
    AudioManagerWhiteRoom amWhiteRoom;
    AudioManager am;

    [SerializeField] float speed = 5f;
    [SerializeField] float jumpForce = 28f;
    [SerializeField] bool isWhiteRoom = true;


    private float nextFootstepTime;
    [SerializeField] float footstepInterval = 0.6f;

    private bool isGrounded;

    void Start()
    {
        am = AudioManager.Get();
        amWhiteRoom = AudioManagerWhiteRoom.Get();

        rb = GetComponent<Rigidbody>();
        nextFootstepTime = 0f;
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
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");

        Vector3 movement = Camera.main.transform.forward * moveVertical + Camera.main.transform.right * moveHorizontal;
        movement.y = 0f;

        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);

        if (isGrounded)
        {
            if (Time.time >= nextFootstepTime && (moveHorizontal != 0f || moveVertical != 0f))
            {
                PlayFootstepSound();
                nextFootstepTime = Time.time + footstepInterval;
            }
        }
    }


    void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
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
