using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LedgeDetection : MonoBehaviour
{
    [SerializeField] private float radius;
    [SerializeField] LayerMask climbableLayer;

    private PlayerMovement player;

    private void Awake()
    {
        player = GetComponentInParent<PlayerMovement>();
    }

    private void Update()
    {
        player.ledgeDetected = Physics.CheckSphere(transform.position, radius, climbableLayer);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
