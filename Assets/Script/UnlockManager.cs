using UnityEngine;

public class UnlockManager : MonoBehaviour
{

    [Header("Objects To Activate")]
    public GameObject toppingsObject;
    public GameObject signObject;
    public GameObject scrambleMakerObject;
    public GameObject foodCartObject;
    public GameObject decorationsObject;
    public GameObject scrambleTropaObject;

    public double toppingsLevel;
    public double signLevel;
    public double scrambleMakerLevel;
    public double foodCartLevel;
    public double decorationsLevel;
    public double scrambleTropaLevel;

    public void StartUnlockManagerAll(
        bool toppingsUnlocked,
        bool signUnlocked,
        bool scrambleMakerUnlocked,
        bool foodCartUnlocked,
        bool decorationsUnlocked,
        bool scrambleTropaUnlocked)
    {
        if (toppingsUnlocked)
            ActivateToppings();

        if (signUnlocked)
            ActivateSigns();

        if (scrambleMakerUnlocked)
            ActivateScrambleMaker();

        if (foodCartUnlocked)
            ActivateFoodCart();

        if (decorationsUnlocked)
            ActivateDecorations();

        if (scrambleTropaUnlocked)
            ActivateScrambleTropa();
    }

    public void ActivateToppings()
    {
        toppingsObject.SetActive(true);

        Debug.Log("UnlockManager: Toppings unlocked!");
    }

    public void ActivateSigns()
    {
        signObject.SetActive(true);

        Debug.Log("UnlockManager: Signs unlocked!");
    }

    public void ActivateScrambleMaker()
    {
        scrambleMakerObject.SetActive(true);

        Debug.Log("UnlockManager: Scramble Maker unlocked!");
    }

    public void ActivateFoodCart()
    {
        foodCartObject.SetActive(true);

        Debug.Log("UnlockManager: Food Cart unlocked!");
    }

    public void ActivateDecorations()
    {
        decorationsObject.SetActive(true);

        Debug.Log("UnlockManager: Decorations unlocked!");
    }

    public void ActivateScrambleTropa()
    {
        scrambleTropaObject.SetActive(true);

        Debug.Log("UnlockManager: Scramble Tropa unlocked!");
    }

    public void resetAll()
    {
        toppingsObject.SetActive(false);
        signObject.SetActive(false);
        scrambleMakerObject.SetActive(false);
        foodCartObject.SetActive(false);
        decorationsObject.SetActive(false);
        scrambleTropaObject.SetActive(false);

        Debug.Log("UnlockManager: Reset");
    }
}