using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateDancer : MonoBehaviour
{
    public bool isActive = false;
    [SerializeField] Vector3 rotationAmount = new Vector3(0, 0, 360); // La cantidad de rotación en cada eje (en grados).
    [SerializeField] float duration = 2.0f; // Duración de una vuelta completa en segundos.
    private Tweener rotationTweener; // Almacenar la referencia a la rotación para detenerla en OnDisable.

    private void OnEnable()
    {
        if (isActive)
        {
            rotationTweener = transform.DORotate(rotationAmount, duration, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Incremental);
        }   
    }

    private void OnDisable()
    {
        if (rotationTweener != null && rotationTweener.IsActive())
        {
            rotationTweener.Kill();
        }
    }
}
