using UnityEngine;

public class CoinCollect : MonoBehaviour
{
    private Main main;

    void Start()
    {
        // Find the Main script in the scene
        main = FindFirstObjectByType<Main>();
    }

    public void TriggerCollect()
    {
        if (main != null)
        {
            main.AddPassiveIncomeToScore();
        }
    }

    void OnMouseDown()
    {
        TriggerCollect();
    }
}