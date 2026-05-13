using System.Collections;
using UnityEngine;

public class ChestSpawner : MonoBehaviour
{
    [Header("Chest Settings")]
    public GameObject chestPrefab;

    [Tooltip("UI object the chest will spawn inside")]
    public Transform targetParent;

    [Header("Spawn Time")]
    [Tooltip("Minimum time before spawn (seconds)")]
    public float minSpawnTime = 120f;

    [Tooltip("Maximum time before spawn (seconds)")]
    public float maxSpawnTime = 180f;

    [Header("Spawn Area")]
    public Vector2 minPosition;
    public Vector2 maxPosition;

    [Header("Pause Settings")]
    [Tooltip("Prevent spawning while game is paused")]
    public bool pauseSpawningWhenPaused = true;

    private GameObject currentChest;

    void Start()
    {
        StartCoroutine(SpawnLoop());
    }

    IEnumerator SpawnLoop()
    {
        while (true)
        {
            float waitTime = Random.Range(minSpawnTime, maxSpawnTime);

            float timer = 0f;

            // Spawn timer
            while (timer < waitTime)
            {
                // Pause timer while game paused
                if (pauseSpawningWhenPaused && Time.timeScale == 0f)
                {
                    yield return null;
                    continue;
                }

                timer += Time.deltaTime;

                yield return null;
            }

            // Only allow one chest
            if (currentChest == null)
            {
                SpawnChest();
            }
        }
    }

    public void SpawnChest()
    {
        // Prevent duplicate chest
        if (currentChest != null)
            return;

        // Spawn as child of target parent
        currentChest = Instantiate(chestPrefab, targetParent);

        RectTransform rect = currentChest.GetComponent<RectTransform>();
        RectTransform prefabRect = chestPrefab.GetComponent<RectTransform>();

        // Copy prefab scale exactly
        rect.localScale = prefabRect.localScale;

        // Reset rotation
        rect.localRotation = Quaternion.identity;

        // Random UI position
        float randomX = Random.Range(minPosition.x, maxPosition.x);
        float randomY = Random.Range(minPosition.y, maxPosition.y);

        rect.anchoredPosition = new Vector2(randomX, randomY);

        StartCoroutine(WatchChest());
    }

    IEnumerator WatchChest()
    {
        while (currentChest != null)
        {
            yield return null;
        }

        currentChest = null;
    }

    // Inspector test button
    [ContextMenu("Spawn Test Chest")]
    void SpawnTestChest()
    {
        SpawnChest();
    }
}