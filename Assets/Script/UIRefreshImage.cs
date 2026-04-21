using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class UIReloadImage : MonoBehaviour
{
    public Image image;
    public string filePath;

    public void ReloadImage()
    {
        if (!System.IO.File.Exists(filePath))
        {
            Debug.LogError("File not found: " + filePath);
            return;
        }

        // Read fresh file
        byte[] data = File.ReadAllBytes(filePath);

        // ALWAYS create a new texture instance
        Texture2D tex = new Texture2D(2, 2, TextureFormat.RGBA32, false);
        tex.LoadImage(data);

        tex.filterMode = FilterMode.Point; // keep sharp noise

        // Destroy old sprite explicitly (VERY important)
        if (image.sprite != null)
        {
            Destroy(image.sprite);
        }

        // Create new sprite (force full rebuild)
        Sprite newSprite = Sprite.Create(
            tex,
            new Rect(0, 0, tex.width, tex.height),
            new Vector2(0.5f, 0.5f),
            100f
        );

        // Hard reset UI reference chain
        image.sprite = null;
        image.overrideSprite = null;

        image.sprite = newSprite;

        // Force UI rebuild
        image.SetAllDirty();
        image.canvasRenderer.SetTexture(null);
    }
}