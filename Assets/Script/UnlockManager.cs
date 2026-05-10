using UnityEngine;

public class UnlockManager : MonoBehaviour
{
    [Header("Unlock Bools Debug")]
    public bool toppingsUnlocked;

    [Header("Objects To Activate")]
    public GameObject toppingsObject;

    public void ActivateToppings()
    {
        toppingsObject.SetActive(true);

        Debug.Log("Toppings unlocked!");
    }

}