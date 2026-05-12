using System.IO;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    int score;
    int incomePerSecond;

    private double toppingsLevel;
    private double signLevel;
    private double scrambleMakerLevel;
    private double foodcartLevel;
    private double decorationsLevel;
    private double scrambleTropaLevel;

    //public void SaveWithParams()
    //{
    //    PlayerData data = new PlayerData(score, incomePerSecond);

    //    string json = JsonUtility.ToJson(data, true);
    //    File.WriteAllText(Application.persistentDataPath + "/player.json", json);

    //    PlayerData data = new PlayerData(
    //        DisplayScore.score,
    //        DisplayScore.incomePerSecond
    //    );

    //    string json = JsonUtility.ToJson(data, true);
    //    File.WriteAllText(Application.persistentDataPath + "/player.json", json);

    //    Debug.Log("Saved!");
    //}

    public void SavePlayer()
    {
        PlayerData data = new PlayerData(score, incomePerSecond, toppingsLevel,
            signLevel, scrambleMakerLevel, foodcartLevel, decorationsLevel, scrambleTropaLevel);

        string json = JsonUtility.ToJson(data, true);

        string path = Application.persistentDataPath + "/player.json";
        File.WriteAllText(path, json); 

        Debug.Log("Saved to: " + path);
    }
}