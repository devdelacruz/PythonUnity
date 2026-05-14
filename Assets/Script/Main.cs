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
    public float coinCollect20 = 2f;
    public float coinCollect50 = 3f;
    public float coinCollect100 = 5f;
    public float coinCollect500 = 6f;
    public float coinCollect1000 = 8f;

    private double toppingsLevel = 0;
    private double signLevel = 0;
    private double scrambleMakerLevel = 0;
    private double foodcartLevel = 0;
    private double decorationsLevel = 0;
    private double scrambleTropaLevel = 0;

    private int maxUpgradeLevel = 10;

    private double toppingsUpgradeAmount = 2.5;
    private double signUpgradeAmount = 8;
    private double scrambleMakerUpgradeAmount = 25;
    private double foodcartUpgradeAmount = 50;
    private double decorationsUpgradeAmount = 100;
    private double scrambleTropaUpgradeAmount = 200;

    private double toppingsUnlockPrice = 50;
    private double signUnlockPrice = 250;
    private double scrambleMakerUnlockPrice = 1000;
    private double foodcartUnlockPrice = 5000;
    private double decorationsUnlockPrice = 10000;
    private double scrambleTropaUnlockPrice = 50000;

    private double toppingsLevelPrice = 2;
    private double signLevelPrice = 10;
    private double scrambleMakerLevelPrice = 50;
    private double foodcartLevelPrice = 150;
    private double decorationsLevelPrice = 500;
    private double scrambleTropaLevelPrice = 1000;

    private double levelPriceIncrease = 2;

    private bool toppingsUnlocked = false;
    private bool signUnlocked = false;
    private bool scrambleMakerUnlocked = false;
    private bool foodcartUnlocked = false;
    private bool decorationsUnlocked = false;
    private bool scrambleTropaUnlocked = false;

    public UnlockManager unlockManager;

    float timer = 0f;

    void Start()
    {
        //ResetUpgradeUnlocks();
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

        score = 0;
        incomePerSecond = 0.1;

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

        unlockManager.resetAll();
    }

    public void ForceReset()
    {
        ResetUpgradeUnlocks();
        ForceUIUpdate();
    }

    public void ForceUIUpdate()
    {
        incomeText.text = incomePerSecond.ToString("0.0");
        scoreText.text = scoreString + score.ToString("0.0");

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
        score += 1;
        scoreText.text = scoreString + score.ToString("0.0");

        FloatingTextSpawner.Instance.ShowText(
            "+1",
            Input.mousePosition
        );
        //ForceUIUpdate();
    }

    public void UpdateScore2()
    {
        score += 50;
        ForceUIUpdate();
    }

    public void BuyToppings()
    {
        if (score < toppingsUnlockPrice) return;

        score -= toppingsUnlockPrice;
        toppingsUnlocked = true;

        toppingsBuyButton.SetActive(false);
        unlockManager.ActivateToppings();

        ForceUIUpdate();
    }

    public void BuySign()
    {
        if (score < signUnlockPrice) return;

        score -= signUnlockPrice;
        signUnlocked = true;

        signBuyButton.SetActive(false);
        unlockManager.ActivateSigns();

        ForceUIUpdate();
    }

    public void BuyScrambleMaker()
    {
        if (score < scrambleMakerUnlockPrice) return;

        score -= scrambleMakerUnlockPrice;
        scrambleMakerUnlocked = true;

        scrambleMakerBuyButton.SetActive(false);
        unlockManager.ActivateScrambleMaker();

        ForceUIUpdate();
    }

    public void BuyFoodcart()
    {
        if (score < foodcartUnlockPrice) return;

        score -= foodcartUnlockPrice;
        foodcartUnlocked = true;

        foodcartBuyButton.SetActive(false);
        unlockManager.ActivateFoodCart();

        ForceUIUpdate();
    }

    public void BuyDecorations()
    {
        if (score < decorationsUnlockPrice) return;

        score -= decorationsUnlockPrice;
        decorationsUnlocked = true;

        decorationsBuyButton.SetActive(false);
        unlockManager.ActivateDecorations();

        ForceUIUpdate();
    }

    public void BuyScrambleTropa()
    {
        if (score < scrambleTropaUnlockPrice) return;

        score -= scrambleTropaUnlockPrice;
        scrambleTropaUnlocked = true;

        scrambleTropaBuyButton.SetActive(false);
        unlockManager.ActivateScrambleTropa();

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

    public void AddPassiveIncomeToScore20()
    {
        score += incomePerSecond * coinCollect20;
        scoreText.text = scoreString + score.ToString("0.0");

        FloatingTextSpawner.Instance.ShowText(
            "+" + (incomePerSecond * coinCollect20).ToString("0.00"),
            Input.mousePosition
        );

        //ForceUIUpdate();
    }

    public void AddPassiveIncomeToScore50()
    {
        score += incomePerSecond * coinCollect50;
        scoreText.text = scoreString + score.ToString("0.0");

        FloatingTextSpawner.Instance.ShowText(
            "+" + (incomePerSecond * coinCollect50).ToString("0.00"),
            Input.mousePosition
        );

        //ForceUIUpdate();
    }

    public void AddPassiveIncomeToScore100()
    {
        score += incomePerSecond * coinCollect100;
        scoreText.text = scoreString + score.ToString("0.0");

        FloatingTextSpawner.Instance.ShowText(
            "+" + (incomePerSecond * coinCollect100).ToString("0.00"),
            Input.mousePosition
        );

        //ForceUIUpdate();
    }

    public void AddPassiveIncomeToScore500()
    {
        score += incomePerSecond * coinCollect500;
        scoreText.text = scoreString + score.ToString("0.0");

        FloatingTextSpawner.Instance.ShowText(
            "+" + (incomePerSecond * coinCollect500).ToString("0.00"),
            Input.mousePosition
        );

        //ForceUIUpdate();
    }

    public void AddPassiveIncomeToScore1000()
    {
        score += incomePerSecond * coinCollect1000;
        scoreText.text = scoreString + score.ToString("0.0");

        FloatingTextSpawner.Instance.ShowText(
            "+" + (incomePerSecond * coinCollect1000).ToString("0.00"),
            Input.mousePosition
        );

        //ForceUIUpdate();
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
        PlayerData data = new PlayerData(
            score,
            incomePerSecond,

            toppingsLevel,
            signLevel,
            scrambleMakerLevel,
            foodcartLevel,
            decorationsLevel,
            scrambleTropaLevel,

            toppingsUnlocked,
            signUnlocked,
            scrambleMakerUnlocked,
            foodcartUnlocked,
            decorationsUnlocked,
            scrambleTropaUnlocked
        );

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

            // Core
            score = data.sc;
            incomePerSecond = data.ic;

            // Levels
            toppingsLevel = data.toppingsLevel;
            signLevel = data.signLevel;
            scrambleMakerLevel = data.scrambleMakerLevel;
            foodcartLevel = data.foodcartLevel;
            decorationsLevel = data.decorationsLevel;
            scrambleTropaLevel = data.scrambleTropaLevel;

            // Unlocks
            toppingsUnlocked = data.toppingsUnlocked;
            signUnlocked = data.signUnlocked;
            scrambleMakerUnlocked = data.scrambleMakerUnlocked;
            foodcartUnlocked = data.foodcartUnlocked;
            decorationsUnlocked = data.decorationsUnlocked;
            scrambleTropaUnlocked = data.scrambleTropaUnlocked;

            // Recalculate prices
            toppingsLevelPrice = 2 * Mathf.Pow((float)levelPriceIncrease, (float)toppingsLevel);
            signLevelPrice = 10 * Mathf.Pow((float)levelPriceIncrease, (float)signLevel);
            scrambleMakerLevelPrice = 50 * Mathf.Pow((float)levelPriceIncrease, (float)scrambleMakerLevel);
            foodcartLevelPrice = 150 * Mathf.Pow((float)levelPriceIncrease, (float)foodcartLevel);
            decorationsLevelPrice = 500 * Mathf.Pow((float)levelPriceIncrease, (float)decorationsLevel);
            scrambleTropaLevelPrice = 1000 * Mathf.Pow((float)levelPriceIncrease, (float)scrambleTropaLevel);

            // Activate visuals
            unlockManager.StartUnlockManagerAll(
                toppingsUnlocked,
                signUnlocked,
                scrambleMakerUnlocked,
                foodcartUnlocked,
                decorationsUnlocked,
                scrambleTropaUnlocked
            );

            ForceUIUpdate();

            Debug.Log("Player Loaded!");
        }
        else
        {
            Debug.LogWarning("Save file not found!");

            ResetUpgradeUnlocks();
            ForceUIUpdate();
        }
    }
}
