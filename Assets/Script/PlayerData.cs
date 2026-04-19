[System.Serializable]
public class PlayerData
{
    public int sc;
    public int ic;

    public PlayerData(int score, int incomePerSecond)
    {
        sc = score;
        ic = incomePerSecond;

    }
}