[System.Serializable]
public class PlayerData
{
    // Core
    public double sc;
    public double ic;

    // Levels
    public double toppingsLevel;
    public double signLevel;
    public double scrambleMakerLevel;
    public double foodcartLevel;
    public double decorationsLevel;
    public double scrambleTropaLevel;

    // Unlocks
    public bool toppingsUnlocked;
    public bool signUnlocked;
    public bool scrambleMakerUnlocked;
    public bool foodcartUnlocked;
    public bool decorationsUnlocked;
    public bool scrambleTropaUnlocked;

    public PlayerData(
        double score,
        double incomePerSecond,

        double toppingsU,
        double signU,
        double scrambleMakerU,
        double foodcartU,
        double decorationsU,
        double scrambleTropaU,

        bool toppingsUnlock,
        bool signUnlock,
        bool scrambleMakerUnlock,
        bool foodcartUnlock,
        bool decorationsUnlock,
        bool scrambleTropaUnlock
    )
    {
        // Core
        sc = score;
        ic = incomePerSecond;

        // Levels
        toppingsLevel = toppingsU;
        signLevel = signU;
        scrambleMakerLevel = scrambleMakerU;
        foodcartLevel = foodcartU;
        decorationsLevel = decorationsU;
        scrambleTropaLevel = scrambleTropaU;

        // Unlocks
        toppingsUnlocked = toppingsUnlock;
        signUnlocked = signUnlock;
        scrambleMakerUnlocked = scrambleMakerUnlock;
        foodcartUnlocked = foodcartUnlock;
        decorationsUnlocked = decorationsUnlock;
        scrambleTropaUnlocked = scrambleTropaUnlock;
    }
}