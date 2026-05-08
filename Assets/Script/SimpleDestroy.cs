using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleDestroy : MonoBehaviour
{
    [Header("Timer Settings")]
    public bool useTimerDestroy = true;

    [Tooltip("Time before object is destroyed")]
    public float destroyTime = 5f;

    void Start()
    {
        if (useTimerDestroy)
        {
            Destroy(gameObject, destroyTime);
        }
    }

    // Manual destroy
    public void simpleDestroy()
    {
        Destroy(gameObject);
    }

    // Toggle timer destroy on/off
    public void simpleSetTimerDestroy(bool state)
    {
        useTimerDestroy = state;
    }
}
