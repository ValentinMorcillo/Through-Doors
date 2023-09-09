using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WhiteDoorController : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        SceneManager.LoadScene("Gameplay");
    }
}
