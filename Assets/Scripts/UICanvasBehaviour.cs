using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UICanvasBehaviour : MonoBehaviour
{
    Camera cam;

    [SerializeField] string intructionPanelText;

    TextMeshProUGUI IntructionText;

    private void Awake()
    {
        cam = Camera.main;
        IntructionText = GetComponentInChildren<TextMeshProUGUI>();
    }

    private void Start()
    {
        IntructionText.text = intructionPanelText;
    }

    private void LateUpdate()
    {
        transform.rotation = cam.transform.rotation;
    }

}
