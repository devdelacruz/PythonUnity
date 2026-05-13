using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleDestroy : MonoBehaviour
{
    [Header("Timer Settings")]
    public bool useTimerDestroy = true;

    [Tooltip("Time before destroy or deactivate")]
    public float destroyTime = 5f;

    [Header("Behavior")]
    public bool useDestroy = true; // true = Destroy, false = SetInactive

    void Start()
    {
        if (useTimerDestroy)
        {
            Invoke(nameof(HandleEndLife), destroyTime);
        }
    }

    void HandleEndLife()
    {
        if (useDestroy)
        {
            Destroy(gameObject);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    // Manual trigger
    public void simpleDestroy()
    {
        HandleEndLife();
    }

    // Toggle timer destroy on/off
    public void simpleSetTimerDestroy(bool state)
    {
        useTimerDestroy = state;

        if (state)
        {
            Invoke(nameof(HandleEndLife), destroyTime);
        }
        else
        {
            CancelInvoke(nameof(HandleEndLife));
        }
    }

    // Optional: switch behavior at runtime
    public void SetDestroyMode(bool destroy)
    {
        useDestroy = destroy;
    }
}