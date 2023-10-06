using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleComplete : MonoBehaviour
{
    [SerializeField] GameObject[] partsPhotos;

    SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();    
    }

    public void checkStatusPhoto()
    {
        bool isComplete = true;
        foreach (GameObject photo in partsPhotos)
        {
            if (!photo.activeSelf)
            {
                isComplete = false;
                break;
            }
        }

        if (isComplete)
        {
            foreach (GameObject photo in partsPhotos)
            {
                photo.SetActive(false);
            }

            spriteRenderer.enabled = true;
        }
    }





















}
