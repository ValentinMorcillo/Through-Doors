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

    AudioSource audioSource;

    private CharacterController characterController;
    private Transform cameraTransform;
    private bool isMoving;

    void Awake()
    {
        characterController = GetComponent<CharacterController>();
        audioSource = GetComponent<AudioSource>();

        cameraTransform = Camera.main.transform;
    }

    void Update()
    {
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
            if (moveDirection.magnitude > 0.1f) // Verificar si hay movimiento
            {
                if (!isMoving) // Iniciar reproducción de pasos si no se está reproduciendo actualmente
                {
                    audioSource.Play();
                    isMoving = true;
                }
            }
            else // No hay movimiento, detener reproducción de pasos si se estaba reproduciendo
            {
                if (isMoving)
                {
                    audioSource.Stop();
                    isMoving = false;
                }
            }
        }
        else // Esta en el aire
        {
            if (isMoving)
            {
                audioSource.Stop();
                isMoving = false;
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
