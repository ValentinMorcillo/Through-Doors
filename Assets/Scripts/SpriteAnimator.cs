using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SpriteAnimator : MonoBehaviour
{
    public Sprite[] sprites;        // Arreglo que contiene tus sprites
    public float frameRate = 0.1f;  // Velocidad de la animación en segundos

    private Image imageRenderer;
    private int currentSpriteIndex;

    private void Start()
    {
        imageRenderer = GetComponent<Image>();
        currentSpriteIndex = 0;

        // Iniciar la animación
        StartCoroutine(Animate());
    }

    private IEnumerator Animate()
    {
        while (true)
        {
            // Cambiar el sprite al siguiente en la secuencia
            imageRenderer.sprite = sprites[currentSpriteIndex];

            // Avanzar al siguiente sprite
            currentSpriteIndex = (currentSpriteIndex + 1) % sprites.Length;

            // Esperar el tiempo de frameRate
            yield return new WaitForSeconds(frameRate);
        }
    }
}