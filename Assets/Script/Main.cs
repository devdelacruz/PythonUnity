using TMPro;
using System.IO;
using UnityEngine;
using UnityEditor.Scripting.Python;

public class Main : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI incomeText;
    public string scoreString = "₱";
    public double score = 0;
    public double incomePerSecond = 0.1;

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

    public void ForceReset()
    {
        score = 0;
        incomePerSecond = 0.1;
        ForceUIUpdate();

        //Reset upgrades
    }

    //void OnEnable()
    //{
    //    ForceReset();
    //}

    void Start()
    {
        ForceUIUpdate();
    }

    public void ForceUIUpdate()
    {
        scoreString += scoreString.ToString();
        incomeText.text = incomePerSecond.ToString();
    }

    public void UpgradeScore()
    {
        incomePerSecond += 0.1;

        incomeText.text = incomePerSecond.ToString();
    }

    public void UpdateScore()
    {
        double scoreCurr = score + 0.1;
        score = scoreCurr;

        // Raw print value as a string
        //scoreText.text = scoreCurr.ToString();
        //incomeText.text = incomePerSecond.ToString();

        // Add ₱ as a string
        scoreString += scoreCurr.ToString();
        incomeText.text = incomePerSecond.ToString();

    }

    public static void SavePlayerPython()
    {
        PythonRunner.RunFile("Assets/Script/new_python_script2.py");
    }

    public void SavePlayer()
    {
        // C#
        PlayerData data = new PlayerData(score, incomePerSecond);

        string json = JsonUtility.ToJson(data, true);

        string path = Application.persistentDataPath + "/player.json";
        File.WriteAllText(path, json);

        Debug.Log("Saved to: " + path);

        // Run Python SaveData
        // SavePlayerPython();
    }

    public void LoadPlayer()
    {
        // Identify JSON path
        string path = Application.persistentDataPath + "/player.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);

            PlayerData data = JsonUtility.FromJson<PlayerData>(json);

            Debug.Log("Name: " + data.sc);
            Debug.Log("Level: " + data.ic);

            score = data.sc;
            incomePerSecond = data.ic;

            scoreString += data.sc.ToString();
            incomeText.text = data.ic.ToString();
        }
        else
        {
            Debug.LogWarning("Save file not found!");
        }
    }
}