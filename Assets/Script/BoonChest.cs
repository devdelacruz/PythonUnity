using UnityEngine;
using UnityEngine.UI;

public class BoonChest : MonoBehaviour
{
    [Header("References")]
    public Main main;

    [Header("Reward Settings")]
    [Range(0f, 1f)]
    public double bonusPercent = 0.15;

    [Header("Chest Settings")]
    public bool destroyAfterOpen = true;
    public bool opened = false;

    [Header("Timer Settings")]
    public bool useTimerDestroy = true;

    [Tooltip("Time before object is destroyed")]
    public float destroyTime = 5f;

    void Start()
    {
        if (useTimerDestroy)
        {
            Destroy(gameObject, destroyTime);
        }

        // Automatically find Main script in scene
        main = FindObjectOfType<Main>();

        if (main == null)
        {
            Debug.LogError("Main script not found in scene!");
        }

        GetComponent<Button>().onClick.AddListener(BoonChestClick);
    }

    public void BoonChestClick()
    {
        Debug.LogError("Before");

        if (opened) return;

        opened = true;

        double bonus = main.score * bonusPercent;

        main.score += bonus;

        //main.ForceUIUpdate();

        if (destroyAfterOpen)
        {
            Destroy(gameObject);
        }
    }
}