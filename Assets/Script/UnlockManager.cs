using UnityEngine;

public class UnlockManager : MonoBehaviour
{
    [Header("Unlock Bools Debug")]
    public bool toppingsUnlocked;

    [Header("Objects To Activate")]
    public GameObject toppingsObject;

    public double toppingsLevel;

    public void startUnlockManagerAll(double toppingsLevel)
    {
        if (toppingsLevel < 0) { return; }
        else { ActivateToppings(); }
    }

    public void ActivateToppings()
    {
        toppingsObject.SetActive(true);

        Debug.Log("UnlockManager: Toppings unlocked!");
    }

    public void resetAll()
    {
        toppingsObject.SetActive(false);

        Debug.Log("UnlockManager: Reset");
    }
}