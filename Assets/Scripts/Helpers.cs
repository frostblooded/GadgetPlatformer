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

public class Timer
{
    public delegate void OnTimerEnd();
    public event OnTimerEnd onTimerEnd;
    public int timesTriggered { get; private set; }
    public bool isDone
    {
        get
        {
            return timesTriggered > 0;
        }
    }

    private float m_timeElapsed;
    private float m_duration;
    private bool m_looping;
    private bool m_isWorking = false;

    public Timer(float duration, bool looping = false)
    {
        m_timeElapsed = 0;
        m_duration = duration;
        m_looping = looping;
        m_isWorking = true;
        timesTriggered = 0;
    }

    public void Restart()
    {
        m_timeElapsed = 0;
        m_isWorking = true;
        timesTriggered = 0;
    }

    public void Stop()
    {
        m_isWorking = false;
    }

    public void Update()
    {
        if (!m_isWorking)
            return;

        m_timeElapsed += Time.deltaTime;

        if (m_timeElapsed >= m_duration)
            CompleteTimer();
    }

    public void CompleteTimer()
    {
        timesTriggered++;
        onTimerEnd?.Invoke();

        if (m_looping)
            m_timeElapsed = 0;
        else
            m_isWorking = false;
    }
}
