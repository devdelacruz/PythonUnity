using System.Collections.Generic;
using UnityEngine;

public class CoinShowerSystem : MonoBehaviour
{
    [Header("UI Parent (Canvas)")]
    public RectTransform canvasParent;

    [Header("Prefab (UI Element)")]
    public GameObject uiPrefab;

    [Header("Noise Texture")]
    public Texture2D maskTexture;

    [Header("Layout")]
    public float cellSize = 10f;

    private List<GameObject> spawnedObjects = new List<GameObject>();

    public void Spawn()
    {
        if (maskTexture == null || uiPrefab == null || canvasParent == null)
        {
            Debug.LogError("Missing references!");
            return;
        }

        ClearAll(); // optional: reset before spawning again

        int width = maskTexture.width;
        int height = maskTexture.height;

        Vector2 offset = new Vector2(
            -width * cellSize * 0.5f,
            -height * cellSize * 0.5f
        );

        Color[] pixels = maskTexture.GetPixels();

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