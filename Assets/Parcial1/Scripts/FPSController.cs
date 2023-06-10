using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSController : MonoBehaviour
{
    [SerializeField] Transform characterBase;
    
    [SerializeField] float movementSpeed = 5.0f;
    [SerializeField] float jumpForce = 500.0f;
    [SerializeField] float gravity = 0.8f;

    [SerializeField] float verticalSpeed = 0.0f;


    private Vector3 moveDirection = Vector3.zero;
    private bool isJumping = false;

    private CharacterController characterController;
    private Transform cameraTransform;


    void Awake()
    {
        characterController = GetComponent<CharacterController>();
        cameraTransform = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        // Movimiento del jugador
        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");

        Vector3 forwardMovement = cameraTransform.forward * verticalMovement;
        Vector3 rightMovement = cameraTransform.right * horizontalMovement;

        forwardMovement.y = 0f;
        rightMovement.y = 0f;

        Vector3 moveDirection = (forwardMovement + rightMovement).normalized;
        moveDirection *= movementSpeed;

       
        if (checkIsGrouded())
        {
            verticalSpeed = 0;
            if (Input.GetButtonDown("Jump"))
            {
                verticalSpeed += jumpForce;
            }
        }

        // Aplicar gravedad
        verticalSpeed -= gravity * Time.deltaTime;

        moveDirection.y = verticalSpeed;

        // Mover al jugador
        characterController.Move(moveDirection * Time.deltaTime);
    }

    bool checkIsGrouded()
    {
        RaycastHit hit;

        return Physics.Raycast(characterBase.position + Vector3.up * 0.1f, Vector3.down, out hit, 0.2f);
    }
}
