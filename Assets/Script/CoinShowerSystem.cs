using System.Collections.Generic;
using UnityEngine;

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

    // 🔥 Track spawned objects
    private List<GameObject> spawnedObjects = new List<GameObject>();

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
            Spawn(maskTexture);
    }

    // Called when external system updates texture
    void OnTextureUpdated(Texture2D newTexture)
    {
        maskTexture = newTexture;
        Spawn(maskTexture);
    }

    // 🔁 Main spawn function
    public void Spawn(Texture2D texture)
    {
        if (texture == null || uiPrefab == null || canvasParent == null)
        {
            Debug.LogError("Missing references!");
            return;
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
                }
            }
        }
    }

    // 🧹 Clear all spawned UI objects
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