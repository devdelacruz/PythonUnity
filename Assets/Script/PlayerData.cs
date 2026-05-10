[System.Serializable]
public class PlayerData
{
    public double sc;
    public double ic;

    public double toppingsLevel;
    //public bool signUnlocked;
    //public bool scrambleMakerUnlocked;
    //public bool foodcartUnlocked;
    //public bool decorationsUnlocked;
    //public bool scrambleTropaUnlocked;

    public PlayerData(double score, double incomePerSecond, double toppingsU)
    {
        sc = score;
        ic = incomePerSecond;
        toppingsLevel = toppingsU;
    }
}