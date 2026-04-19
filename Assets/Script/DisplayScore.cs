using TMPro;
using System.IO;
using UnityEngine;

public class DisplayScore : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI incomeText;
    public int score = 0;
    public int incomePerSecond = 1;

    float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 1f)
        {
            score += incomePerSecond;
            timer -= 1f;
        }
        scoreText.text = score.ToString();
    }

    //private void ForceReset()
    //{
    //    score = 0;
    //    incomePerSecond = 0;
    //}   

    //private void OnEnable()
    //{
    //    ForceReset();
    //}

    void Start()
    {
        scoreText.text = score.ToString();
    }

    public void UpgradeScore()
    {
        incomePerSecond += 1;

        incomeText.text = incomePerSecond.ToString();
    }

    public void UpdateScore()
    {
        //scoreText.text = value.ToString();
        int scoreCurr = score + 1;
        score = scoreCurr;

        scoreText.text = scoreCurr.ToString();
        incomeText.text = incomePerSecond.ToString();
    }

    public void SavePlayer()
    {
        PlayerData data = new PlayerData(score, incomePerSecond);

        string json = JsonUtility.ToJson(data, true);

        string path = Application.persistentDataPath + "/player.json";
        File.WriteAllText(path, json);

        Debug.Log("Saved to: " + path);
    }

    public void LoadPlayer()
    {
        string path = Application.persistentDataPath + "/player.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);

            PlayerData data = JsonUtility.FromJson<PlayerData>(json);

            Debug.Log("Name: " + data.sc);
            Debug.Log("Level: " + data.ic);
        }
        else
        {
            Debug.LogWarning("Save file not found!");
        }
    }
}