[System.Serializable]
public class PlayerData
{
    public double sc;
    public double ic;

    public PlayerData(double score, double incomePerSecond)
    {
        sc = score;
        ic = incomePerSecond;

    }
}