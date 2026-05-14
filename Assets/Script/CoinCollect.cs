using UnityEngine;

public class CoinCollect : MonoBehaviour
{
    private Main main;

    public bool twenty;
    public bool fifty;
    public bool hundred;
    public bool fiveHundred;
    public bool thousand;

    void Start()
    {
        // Find the Main script in the scene
        main = FindFirstObjectByType<Main>();
    }

    public void TriggerCollect()
    {
        if (main == null) return;

        if (twenty)
        {
            main.AddPassiveIncomeToScore20();
        }
        else if (fifty)
        {
            main.AddPassiveIncomeToScore50();
        }
        else if (hundred)
        {
            main.AddPassiveIncomeToScore100();
        }
        else if (fiveHundred)
        {
            main.AddPassiveIncomeToScore500();
        }
        else if (thousand)
        {
            main.AddPassiveIncomeToScore1000();
        }
        else
        {
            // fallback if no bool is set
            main.AddPassiveIncomeToScore20();
        }
    }

    void OnMouseDown()
    {
        TriggerCollect();
    }
}