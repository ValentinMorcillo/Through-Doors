using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffMusicalBox : MonoBehaviour
{
    [SerializeField] GameObject muscialBox;


    private void OnEnable()
    {
        muscialBox.SetActive(false);
    }

    private void OnDisable()
    {
        muscialBox.SetActive(true);
        
    }

}
