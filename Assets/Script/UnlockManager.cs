using UnityEngine;

public class UnlockManager : MonoBehaviour
{
    [Header("Unlock Bools Debug")]
    public bool toppingsUnlocked;
    public bool signUnlocked;
    public bool scrambleMakerUnlocked;
    public bool foodCartUnlocked;
    public bool decorationsUnlocked;
    public bool scrambleTropaUnlocked;

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

    public void startUnlockManagerAll(double toppingsLevel, double signLevel, 
        double scrambleMakerLevel, double foodCartLevel, double decorationsLevel, double scrambleTropaLevel)
    {
        if (toppingsLevel != 0) { ActivateToppings(); }
        else {  }

        if (signLevel != 0) { ActivateSigns(); }
        else {  }

        if (scrambleMakerLevel != 0) { ActivateScrambleMaker(); }
        else {  }

        if (foodCartLevel != 0) { ActivateFoodCart(); }
        else {  }

        if (decorationsLevel != 0) { ActivateDecorations(); }
        else {  }

        if (scrambleTropaLevel != 0) {  }
        else {  }
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