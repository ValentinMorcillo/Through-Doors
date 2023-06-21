using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSController : MonoBehaviour
{
    [SerializeField] Transform characterBase;
    private Rigidbody rb;
    
    [SerializeField] float speed = 5f;
    [SerializeField] float jumpForce = 28f;

    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
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
    }

   
    void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    private void CheckIsGrounded()
    {

        isGrounded = Physics.Raycast(characterBase.position + Vector3.up * 0.1f, Vector3.down, out RaycastHit hit, 0.2f) ;
    }

}
