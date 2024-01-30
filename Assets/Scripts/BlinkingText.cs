using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BlinkingText : MonoBehaviour
{
    public float intervaloTitilacion = 1.0f; // Intervalo de titilación en segundos

    private TextMeshProUGUI text;
    private bool isVisible = true;

    private void Start()
    {
        text = GetComponentInChildren<TextMeshProUGUI>();
        StartCoroutine(Blinking());
    }

    private IEnumerator Blinking()
    {
        while (true)
        {
            isVisible = !isVisible;
            text.enabled = isVisible;
            yield return new WaitForSeconds(intervaloTitilacion);
        }
    }
}
