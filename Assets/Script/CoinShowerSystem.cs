using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BinaryNoiseUIPrefabSpawner : MonoBehaviour
{
    [Header("UI Parent (Canvas)")]
    public RectTransform canvasParent;

    [Header("Prefab (UI Element)")]
    public GameObject uiPrefab;

    [Header("Noise Texture (fallback / initial)")]
    public Texture2D maskTexture;

    [Header("Layout")]
    public float cellSize = 10f;

    [Header("Random Spawn Delay")]
    public float minSpawnDelay = 0.1f;
    public float maxSpawnDelay = 0.25f;

    // Track spawned objects
    private List<GameObject> spawnedObjects = new List<GameObject>();

    // Shows in the Inspector
    public UnityEvent onButtonPressed;

    private Coroutine spawnRoutine;

    public void TriggerEvent()
    {
        onButtonPressed.Invoke();
    }

    void OnEnable()
    {
        // Listen for texture reloads
        UIReloadImage.OnTextureReloaded += OnTextureUpdated;
    }

    void OnDisable()
    {
        UIReloadImage.OnTextureReloaded -= OnTextureUpdated;
    }

    void Start()
    {
        if (maskTexture != null)
            StartSpawn(maskTexture);
    }

    // Called when external system updates texture
    void OnTextureUpdated(Texture2D newTexture)
    {
        maskTexture = newTexture;
        StartSpawn(maskTexture);
    }

    // Safely start spawning
    void StartSpawn(Texture2D texture)
    {
        // Stop old spawn coroutine if still running
        if (spawnRoutine != null)
            StopCoroutine(spawnRoutine);

        spawnRoutine = StartCoroutine(SpawnRoutine(texture));
    }

    // Main coroutine spawn function
    IEnumerator SpawnRoutine(Texture2D texture)
    {
        if (texture == null || uiPrefab == null || canvasParent == null)
        {
            Debug.LogError("Missing references!");
            yield break;
        }

        ClearAll();

        int width = texture.width;
        int height = texture.height;

        Vector2 offset = new Vector2(
            -width * cellSize * 0.5f,
            -height * cellSize * 0.5f
        );

        Color[] pixels = texture.GetPixels();

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Color pixel = pixels[x + y * width];

                // Binary rule: white = spawn
                if (pixel.r > 0.5f)
                {
                    Vector2 pos = offset + new Vector2(
                        x * cellSize,
                        y * cellSize
                    );

                    GameObject obj = Instantiate(uiPrefab, canvasParent);

                    RectTransform rt = obj.GetComponent<RectTransform>();

                    if (rt != null)
                    {
                        rt.anchoredPosition = pos;
                        rt.sizeDelta = new Vector2(cellSize, cellSize);
                    }

                    spawnedObjects.Add(obj);

                    // Random delay before next spawn
                    yield return new WaitForSeconds(
                        Random.Range(minSpawnDelay, maxSpawnDelay)
                    );
                }
            }
        }
    }

    // Clear all spawned UI objects
    public void ClearAll()
    {
        for (int i = 0; i < spawnedObjects.Count; i++)
        {
            if (spawnedObjects[i] != null)
                Destroy(spawnedObjects[i]);
        }

        spawnedObjects.Clear();
    }
}