using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

static class Helpers
{
    public static T FindClosest<T>(Vector3 point, T[] elements)
    where T : MonoBehaviour
    {
        T closest = default;
        float closestDistSqr = Mathf.Infinity;

        foreach (T element in elements)
        {
            float distSqr = (point - element.transform.position).sqrMagnitude;

            if (distSqr < closestDistSqr)
            {
                closest = element;
                closestDistSqr = distSqr;
            }
        }

        return closest;
    }
}

// Use as [ReadOnly] to mark a field that is serealizable as noneditable for the editor
public class ReadOnlyAttribute : PropertyAttribute { }

[CustomPropertyDrawer(typeof(ReadOnlyAttribute))]
public class ReadOnlyDrawer : PropertyDrawer
{
    public override float GetPropertyHeight(SerializedProperty property,
                                            GUIContent label)
    {
        return EditorGUI.GetPropertyHeight(property, label, true);
    }

    public override void OnGUI(Rect position,
                               SerializedProperty property,
                               GUIContent label)
    {
        GUI.enabled = false;
        EditorGUI.PropertyField(position, property, label, true);
        GUI.enabled = true;
    }
}
