using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Method for any Inspectable object that throws out the behaviour when inspected.
/// </summary>
public class InspectObjectType : MonoBehaviour
{
    [Header("== Inspect Object Type ===========")]
    [Space(10)]

    [SerializeField] private bool noType;
    [SerializeField] private bool textType;


    [SerializeField] internal string objectName;
    [ConditionalField("textType")]
    [SerializeField, TextArea(3, 6)] internal string itemDescriptionText;

    /// <summary>
    /// Method that gives back the bool type when required.
    /// Made for the NewInspectSystem script to give back the type of the object being inspected.
    /// </summary>
    /// <returns>Type of bool of the object being inspected, true = textType, false = noType</returns>
    internal bool GetObjectType()
    {
        if (textType) return true; else {  return false; }

    }


}
