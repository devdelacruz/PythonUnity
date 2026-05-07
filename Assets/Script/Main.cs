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

    public TextMeshProUGUI toppingsNextPriceText;
    public TextMeshProUGUI signNextPriceText;
    public TextMeshProUGUI scrambleMakerNextPriceText;
    public TextMeshProUGUI foodcartNextPriceText;
    public TextMeshProUGUI decorationsNextPriceText;
    public TextMeshProUGUI scrambleTropaNextPriceText;

    public GameObject toppingsBuyButton;
    public GameObject signBuyButton;
    public GameObject scrambleMakerBuyButton;
    public GameObject foodcartBuyButton;
    public GameObject decorationsBuyButton;
    public GameObject scrambleTropaBuyButton;

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
    private double scrambleMakerUpgradeAmount = 2.5;
    private double foodcartUpgradeAmount = 5.0;
    private double decorationsUpgradeAmount = 10.0;
    private double scrambleTropaUpgradeAmount = 25.0;

    private double toppingsUnlockPrice = 5;
    private double signUnlockPrice = 25;
    private double scrambleMakerUnlockPrice = 100;
    private double foodcartUnlockPrice = 500;
    private double decorationsUnlockPrice = 1000;
    private double scrambleTropaUnlockPrice = 5000;

    private double toppingsLevelPrice = 2;
    private double signLevelPrice = 10;
    private double scrambleMakerLevelPrice = 50;
    private double foodcartLevelPrice = 150;
    private double decorationsLevelPrice = 500;
    private double scrambleTropaLevelPrice = 1000;

    private double levelPriceIncrease = 1.5;

    private bool toppingsUnlocked = false;
    private bool signUnlocked = false;
    private bool scrambleMakerUnlocked = false;
    private bool foodcartUnlocked = false;
    private bool decorationsUnlocked = false;
    private bool scrambleTropaUnlocked = false;

    float timer = 0f;

    void Start()
    {
        ResetUpgradeUnlocks();
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

        scoreText.text = scoreString + score.ToString("0.0");
    }

    public void ResetUpgradeUnlocks()
    {
        toppingsUnlocked = false;
        signUnlocked = false;
        scrambleMakerUnlocked = false;
        foodcartUnlocked = false;
        decorationsUnlocked = false;
        scrambleTropaUnlocked = false;

        toppingsLevel = 0;
        signLevel = 0;
        scrambleMakerLevel = 0;
        foodcartLevel = 0;
        decorationsLevel = 0;
        scrambleTropaLevel = 0;

        toppingsLevelPrice = 2;
        signLevelPrice = 10;
        scrambleMakerLevelPrice = 50;
        foodcartLevelPrice = 150;
        decorationsLevelPrice = 500;
        scrambleTropaLevelPrice = 1000;

        toppingsBuyButton.SetActive(true);
        signBuyButton.SetActive(true);
        scrambleMakerBuyButton.SetActive(true);
        foodcartBuyButton.SetActive(true);
        decorationsBuyButton.SetActive(true);
        scrambleTropaBuyButton.SetActive(true);
    }

    public void ForceReset()
    {
        score = 0;
        incomePerSecond = 0.1;

        ResetUpgradeUnlocks();
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

        UpdateNextLevelPrices();
        UpdateBuyButtons();
    }

    public void UpdateScore()
    {
        score += 0.1;
        ForceUIUpdate();
    }

    public void BuyToppings()
    {
        if (score < toppingsUnlockPrice) return;

        score -= toppingsUnlockPrice;
        toppingsUnlocked = true;

        toppingsBuyButton.SetActive(false);

        ForceUIUpdate();
    }

    public void BuySign()
    {
        if (score < signUnlockPrice) return;

        score -= signUnlockPrice;
        signUnlocked = true;

        signBuyButton.SetActive(false);

        ForceUIUpdate();
    }

    public void BuyScrambleMaker()
    {
        if (score < scrambleMakerUnlockPrice) return;

        score -= scrambleMakerUnlockPrice;
        scrambleMakerUnlocked = true;

        scrambleMakerBuyButton.SetActive(false);

        ForceUIUpdate();
    }

    public void BuyFoodcart()
    {
        if (score < foodcartUnlockPrice) return;

        score -= foodcartUnlockPrice;
        foodcartUnlocked = true;

        foodcartBuyButton.SetActive(false);

        ForceUIUpdate();
    }

    public void BuyDecorations()
    {
        if (score < decorationsUnlockPrice) return;

        score -= decorationsUnlockPrice;
        decorationsUnlocked = true;

        decorationsBuyButton.SetActive(false);

        ForceUIUpdate();
    }

    public void BuyScrambleTropa()
    {
        if (score < scrambleTropaUnlockPrice) return;

        score -= scrambleTropaUnlockPrice;
        scrambleTropaUnlocked = true;

        scrambleTropaBuyButton.SetActive(false);

        ForceUIUpdate();
    }

    public void UpgradeToppings()
    {
        if (!toppingsUnlocked) return;
        if (toppingsLevel >= maxUpgradeLevel) return;
        if (score < toppingsLevelPrice) return;

        score -= toppingsLevelPrice;
        toppingsLevel++;
        incomePerSecond += toppingsUpgradeAmount;
        toppingsLevelPrice *= levelPriceIncrease;

        ForceUIUpdate();
    }

    public void UpgradeSign()
    {
        if (!signUnlocked) return;
        if (signLevel >= maxUpgradeLevel) return;
        if (score < signLevelPrice) return;

        score -= signLevelPrice;
        signLevel++;
        incomePerSecond += signUpgradeAmount;
        signLevelPrice *= levelPriceIncrease;

        ForceUIUpdate();
    }

    public void UpgradeScrambleMaker()
    {
        if (!scrambleMakerUnlocked) return;
        if (scrambleMakerLevel >= maxUpgradeLevel) return;
        if (score < scrambleMakerLevelPrice) return;

        score -= scrambleMakerLevelPrice;
        scrambleMakerLevel++;
        incomePerSecond += scrambleMakerUpgradeAmount;
        scrambleMakerLevelPrice *= levelPriceIncrease;

        ForceUIUpdate();
    }

    public void UpgradeFoodcart()
    {
        if (!foodcartUnlocked) return;
        if (foodcartLevel >= maxUpgradeLevel) return;
        if (score < foodcartLevelPrice) return;

        score -= foodcartLevelPrice;
        foodcartLevel++;
        incomePerSecond += foodcartUpgradeAmount;
        foodcartLevelPrice *= levelPriceIncrease;

        ForceUIUpdate();
    }

    public void UpgradeDecorations()
    {
        if (!decorationsUnlocked) return;
        if (decorationsLevel >= maxUpgradeLevel) return;
        if (score < decorationsLevelPrice) return;

        score -= decorationsLevelPrice;
        decorationsLevel++;
        incomePerSecond += decorationsUpgradeAmount;
        decorationsLevelPrice *= levelPriceIncrease;

        ForceUIUpdate();
    }

    public void UpgradeScrambleTropa()
    {
        if (!scrambleTropaUnlocked) return;
        if (scrambleTropaLevel >= maxUpgradeLevel) return;
        if (score < scrambleTropaLevelPrice) return;

        score -= scrambleTropaLevelPrice;
        scrambleTropaLevel++;
        incomePerSecond += scrambleTropaUpgradeAmount;
        scrambleTropaLevelPrice *= levelPriceIncrease;

        ForceUIUpdate();
    }

    public void ToppingsLevelDisplay()
    {
        toppingsLevelText.text = "Toppings Level: " + toppingsLevel + "/" + maxUpgradeLevel;
    }

    public void SignLevelDisplay()
    {
        signLevelText.text = "Sign Level: " + signLevel + "/" + maxUpgradeLevel;
    }

    public void ScrambleMakerLevelDisplay()
    {
        scrambleMakerLevelText.text = "Scramble Maker Level: " + scrambleMakerLevel + "/" + maxUpgradeLevel;
    }

    public void FoodcartLevelDisplay()
    {
        foodcartLevelText.text = "Foodcart Level: " + foodcartLevel + "/" + maxUpgradeLevel;
    }

    public void DecorationsLevelDisplay()
    {
        decorationsLevelText.text = "Decorations Level: " + decorationsLevel + "/" + maxUpgradeLevel;
    }

    public void ScrambleTropaLevelDisplay()
    {
        scrambleTropaLevelText.text = "ScrambleTropa Level: " + scrambleTropaLevel + "/" + maxUpgradeLevel;
    }

    public void UpdateNextLevelPrices()
    {
        toppingsNextPriceText.text = toppingsLevel >= maxUpgradeLevel ? "MAX" : "Next: " + scoreString + toppingsLevelPrice.ToString("0");
        signNextPriceText.text = signLevel >= maxUpgradeLevel ? "MAX" : "Next: " + scoreString + signLevelPrice.ToString("0");
        scrambleMakerNextPriceText.text = scrambleMakerLevel >= maxUpgradeLevel ? "MAX" : "Next: " + scoreString + scrambleMakerLevelPrice.ToString("0");
        foodcartNextPriceText.text = foodcartLevel >= maxUpgradeLevel ? "MAX" : "Next: " + scoreString + foodcartLevelPrice.ToString("0");
        decorationsNextPriceText.text = decorationsLevel >= maxUpgradeLevel ? "MAX" : "Next: " + scoreString + decorationsLevelPrice.ToString("0");
        scrambleTropaNextPriceText.text = scrambleTropaLevel >= maxUpgradeLevel ? "MAX" : "Next: " + scoreString + scrambleTropaLevelPrice.ToString("0");
    }

    public void UpdateBuyButtons()
    {
        toppingsBuyButton.SetActive(!toppingsUnlocked);
        signBuyButton.SetActive(!signUnlocked);
        scrambleMakerBuyButton.SetActive(!scrambleMakerUnlocked);
        foodcartBuyButton.SetActive(!foodcartUnlocked);
        decorationsBuyButton.SetActive(!decorationsUnlocked);
        scrambleTropaBuyButton.SetActive(!scrambleTropaUnlocked);
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
