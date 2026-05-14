using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BinaryNoiseUIPrefabSpawner : MonoBehaviour
{
    [Header("UI Parent (Canvas)")]
    public RectTransform canvasParent;

    [Header("Prefab Pool (Weighted)")]
    public List<WeightedPrefab> uiPrefabs = new List<WeightedPrefab>();

    [Header("Noise Texture (fallback / initial)")]
    public Texture2D maskTexture;

    [Header("Layout")]
    public float cellSize = 10f;

    [Header("Random Spawn Delay")]
    public float minSpawnDelay = 0.1f;
    public float maxSpawnDelay = 0.25f;

    private List<GameObject> spawnedObjects = new List<GameObject>();
    public UnityEvent onButtonPressed;

    private Coroutine spawnRoutine;

    [System.Serializable]
    public class WeightedPrefab
    {
        public GameObject prefab;
        [Min(0f)]
        public float weight = 1f;
    }

    public void TriggerEvent()
    {
        onButtonPressed.Invoke();
    }

    void OnEnable()
    {
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

    void OnTextureUpdated(Texture2D newTexture)
    {
        maskTexture = newTexture;
        StartSpawn(maskTexture);
    }

    public void StartSpawn(Texture2D texture)
    {
        if (spawnRoutine != null)
            StopCoroutine(spawnRoutine);

        spawnRoutine = StartCoroutine(SpawnRoutine(texture));
    }

    IEnumerator SpawnRoutine(Texture2D texture)
    {
        if (texture == null || canvasParent == null || uiPrefabs.Count == 0)
        {
            Debug.LogError("Missing references or prefabs!");
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

                if (pixel.r > 0.5f)
                {
                    Vector2 pos = offset + new Vector2(
                        x * cellSize,
                        y * cellSize
                    );

                    GameObject prefab = GetWeightedRandomPrefab();
                    GameObject obj = Instantiate(prefab, canvasParent);

                    RectTransform rt = obj.GetComponent<RectTransform>();

                    if (rt != null)
                    {
                        rt.anchoredPosition = pos;
                        rt.sizeDelta = new Vector2(cellSize, cellSize);
                    }

                    spawnedObjects.Add(obj);

                    yield return new WaitForSeconds(
                        Random.Range(minSpawnDelay, maxSpawnDelay)
                    );
                }
            }
        }
    }

    GameObject GetWeightedRandomPrefab()
    {
        float totalWeight = 0f;

        for (int i = 0; i < uiPrefabs.Count; i++)
        {
            if (uiPrefabs[i].prefab != null)
                totalWeight += uiPrefabs[i].weight;
        }

        float random = Random.Range(0f, totalWeight);

        for (int i = 0; i < uiPrefabs.Count; i++)
        {
            var entry = uiPrefabs[i];

            if (entry.prefab == null)
                continue;

            if (random < entry.weight)
                return entry.prefab;

            random -= entry.weight;
        }

        return uiPrefabs[0].prefab;
    }

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