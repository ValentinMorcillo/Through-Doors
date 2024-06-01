#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System.Reflection;

[CustomPropertyDrawer(typeof(ConditionalFieldAttribute))]
public class ConditionalFieldDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        ConditionalFieldAttribute conditional = (ConditionalFieldAttribute)attribute;
        SerializedProperty conditionProperty = property.serializedObject.FindProperty(conditional.ConditionBool);

        if (conditionProperty != null && conditionProperty.boolValue)
        {
            EditorGUI.PropertyField(position, property, label, true);
        }
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        ConditionalFieldAttribute conditional = (ConditionalFieldAttribute)attribute;
        SerializedProperty conditionProperty = property.serializedObject.FindProperty(conditional.ConditionBool);

        if (conditionProperty != null && conditionProperty.boolValue)
        {
            return EditorGUI.GetPropertyHeight(property, label);
        }
        else
        {
            return -EditorGUIUtility.standardVerticalSpacing;
        }
    }
}
#endif