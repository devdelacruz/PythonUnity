[System.Serializable]
public class PlayerData
{
    public double sc;
    public double ic;

    public double toppingsLevel;
    public double signLevel;
    public double scrambleMakerLevel;
    public double foodcartLevel;
    public double decorationsLevel;
    public double scrambleTropaLevel;

    public PlayerData(double score, double incomePerSecond, double toppingsU, 
        double signU, double scrambleMakerU, double foodcartU, double decorationsU, double scrambleTropaU)
    {
        sc = score;
        ic = incomePerSecond;
        toppingsLevel = toppingsU;
        signLevel = signU;
        scrambleMakerLevel = scrambleMakerU;
        foodcartLevel = foodcartU;
        decorationsLevel = decorationsU;
        scrambleTropaLevel = scrambleTropaU;
    }
}