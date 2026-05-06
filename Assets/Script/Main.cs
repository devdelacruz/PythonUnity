using TMPro;
using System.IO;
using UnityEngine;
using UnityEditor.Scripting.Python;

public class Main : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI incomeText;

    public TextMeshProUGUI toppingsLevelText;
    public TextMeshProUGUI signLevelText;
    public TextMeshProUGUI scrambleMakerLevelText;
    public TextMeshProUGUI foodcartLevelText;
    public TextMeshProUGUI decorationsLevelText;
    public TextMeshProUGUI scrambleTropaLevelText;

    public string scoreString = "₱";
    public double score = 0;
    public double incomePerSecond = 0.1;

    private int toppingsLevel = 0;
    private int signLevel = 0;
    private int scrambleMakerLevel = 0;
    private int foodcartLevel = 0;
    private int decorationsLevel = 0;
    private int scrambleTropaLevel = 0;

    private int maxUpgradeLevel = 10;

    private double toppingsUpgradeAmount = 0.5;
    private double signUpgradeAmount = 1.0;
    private double scrambleMakerUpgradeAmount = 2.0;
    private double foodcartUpgradeAmount = 4.0;
    private double decorationsUpgradeAmount = 8.0;
    private double scrambleTropaUpgradeAmount = 15.0;

    float timer = 0f;

    void Start()
    {
        ForceUIUpdate();
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 1f)
        {
            score += incomePerSecond;
            timer -= 1f;
        }

        scoreText.text = score.ToString("0.0");
    }

    public void ForceReset()
    {
        score = 0;
        incomePerSecond = 1.0;

        toppingsLevel = 0;
        signLevel = 0;
        scrambleMakerLevel = 0;
        foodcartLevel = 0;
        decorationsLevel = 0;
        scrambleTropaLevel = 0;

        ForceUIUpdate();
    }

    public void ForceUIUpdate()
    {
        incomeText.text = incomePerSecond.ToString("0.0");

        ToppingsLevelDisplay();
        SignLevelDisplay();
        ScrambleMakerLevelDisplay();
        FoodcartLevelDisplay();
        DecorationsLevelDisplay();
        ScrambleTropaLevelDisplay();
    }

    public void UpdateScore()
    {
        score += 1.0;
        incomeText.text = incomePerSecond.ToString("0.0");
    }

    public void UpgradeToppings()
    {
        if (toppingsLevel >= maxUpgradeLevel)
        {
            return;
        }

        toppingsLevel++;
        incomePerSecond += toppingsUpgradeAmount;

        ForceUIUpdate();
    }

    public void UpgradeSign()
    {
        if (signLevel >= maxUpgradeLevel)
        {
            return;
        }

        signLevel++;
        incomePerSecond += signUpgradeAmount;

        ForceUIUpdate();
    }

    public void UpgradeScrambleMaker()
    {
        if (scrambleMakerLevel >= maxUpgradeLevel)
        {
            return;
        }

        scrambleMakerLevel++;
        incomePerSecond += scrambleMakerUpgradeAmount;

        ForceUIUpdate();
    }

    public void UpgradeFoodcart()
    {
        if (foodcartLevel >= maxUpgradeLevel)
        {
            return;
        }

        foodcartLevel++;
        incomePerSecond += foodcartUpgradeAmount;

        ForceUIUpdate();
    }

    public void UpgradeDecorations()
    {
        if (decorationsLevel >= maxUpgradeLevel)
        {
            return;
        }

        decorationsLevel++;
        incomePerSecond += decorationsUpgradeAmount;

        ForceUIUpdate();
    }

    public void UpgradeScrambleTropa()
    {
        if (scrambleTropaLevel >= maxUpgradeLevel)
        {
            return;
        }

        scrambleTropaLevel++;
        incomePerSecond += scrambleTropaUpgradeAmount;

        ForceUIUpdate();
    }

    public void ToppingsLevelDisplay()
    {
        toppingsLevelText.text = toppingsLevel + "/" + maxUpgradeLevel;
    }

    public void SignLevelDisplay()
    {
        signLevelText.text = signLevel + "/" + maxUpgradeLevel;
    }

    public void ScrambleMakerLevelDisplay()
    {
        scrambleMakerLevelText.text = scrambleMakerLevel + "/" + maxUpgradeLevel;
    }

    public void FoodcartLevelDisplay()
    {
        foodcartLevelText.text = foodcartLevel + "/" + maxUpgradeLevel;
    }

    public void DecorationsLevelDisplay()
    {
        decorationsLevelText.text = decorationsLevel + "/" + maxUpgradeLevel;
    }

    public void ScrambleTropaLevelDisplay()
    {
        scrambleTropaLevelText.text = scrambleTropaLevel + "/" + maxUpgradeLevel;
    }

    public static void SavePlayerPython()
    {
        PythonRunner.RunFile("Assets/Script/new_python_script2.py");
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

            Debug.Log("Score: " + data.sc);
            Debug.Log("Income: " + data.ic);

            score = data.sc;
            incomePerSecond = data.ic;

            ForceUIUpdate();
        }
        else
        {
            Debug.LogWarning("Save file not found!");
        }
    }
}
