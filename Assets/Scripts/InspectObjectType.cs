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
    [SerializeField] private bool inspectOnly;
    [SerializeField] private bool textOnly;
    [SerializeField] private bool inspectAndText;
    [SerializeField] private bool oneTimeOnly;
    [SerializeField] private bool scaleOverride;


    [Header("-- Default Object Name ----------")]
    [Space(10)]
    [SerializeField] internal string objectName;

    [Header("-- One Time Only----------")]
    [Space(10)]
    [ConditionalField("oneTimeOnly")]
    [SerializeField] internal bool clicked;

    [ConditionalField("inspectAndText")]
    [Header("-- Text Type Behaviours ----------")]
    [Space(10)]

    [SerializeField, TextArea(3, 6)] internal string itemDescriptionText;
    [ConditionalField("textOnly")]
    [SerializeField] internal float messageDuration;
    [ConditionalField("textOnly")]
    [SerializeField, TextArea(3, 6)] internal string itemDescriptionOnlyText;


    [ConditionalField("scaleOverride")]
    [Header("-- Scale Override Behaviours ----------")]
    [Header("-- Reminder, default Values are: Initial: 0.7, Min: 0.5 ,Max: 1 ----------")]
    [Space(10)]

    [SerializeField, Range(0.1f,1.5f)] internal float initialScale;
    [ConditionalField("scaleOverride")]
    [SerializeField,Range(0.1f,1.0f)] internal float minScale;
    [ConditionalField("scaleOverride")]
    [SerializeField,Range(0.1f,4.0f)] internal float maxScale;


    /// <summary>
    /// Method that gives back the bool type when required.
    /// Made for the NewInspectSystem script to give back the type of the object being inspected.
    /// </summary>
    /// <returns>Type of bool of the object being inspected, true = textType, false = noType</returns>
    internal int GetObjectType()
    {
        if (inspectOnly) return 0;
        if (textOnly) return 1;
        if (inspectAndText) return 2;
        if (oneTimeOnly) return 3; else
        {
            return 99;
        }
    }
    /// <summary>
    /// Method that gives back the override scale bool when required.
    /// Made for the NewInspectSystem script to give back the initial, min and max scale values for it's inspection.
    /// </summary>
    /// <returns>Personalized object initial, minimal and maximum scale float values.</returns>
    internal bool OverrideScale()
    {
        if (scaleOverride) return true; else { return false; }
    }


}
