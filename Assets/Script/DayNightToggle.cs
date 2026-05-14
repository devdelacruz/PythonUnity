using UnityEngine;
using UnityEngine.Events;

public class DayNightToggle : MonoBehaviour
{
    public UnityEvent onDay;
    public UnityEvent onNight;

    private bool isNight;

    public void Toggle()
    {
        isNight = !isNight;

        if (isNight)
            onNight?.Invoke();
        else
            onDay?.Invoke();
    }
}