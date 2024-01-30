using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreditsController : MonoBehaviour
{
    [SerializeField] Button exitButton;


    void Start()
    {
        Cursor.lockState = CursorLockMode.None;

        exitButton.onClick.AddListener(() => Application.Quit());
    }


}
