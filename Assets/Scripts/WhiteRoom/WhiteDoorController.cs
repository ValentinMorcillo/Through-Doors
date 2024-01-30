using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WhiteDoorController : MonoBehaviour
{
    [SerializeField] string nameTonextScene;

    private void OnTriggerEnter(Collider other)
    {
        SceneManager.Get().LoadScene(nameTonextScene);
    }

}
