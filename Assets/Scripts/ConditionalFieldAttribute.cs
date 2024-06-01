using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConditionalFieldAttribute : PropertyAttribute
{
    public string ConditionBool;

    public ConditionalFieldAttribute(string conditionBool)
    {
        this.ConditionBool = conditionBool;
    }
}
