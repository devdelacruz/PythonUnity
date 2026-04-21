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

    public void CoinSpawn()
    {
        if (maskTexture == null || uiPrefab == null || canvasParent == null)
        {
            Debug.LogError("Missing references!");
            return;
        }

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

                // Binary mask: white = spawn
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

                    // Optional: pass data to custom script
                    // obj.GetComponent<YourUIElement>()?.Init(pixel);
                }
            }
        }
    }
}