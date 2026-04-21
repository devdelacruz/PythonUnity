using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;

public class UIReloadImage : MonoBehaviour
{
    public Image image;
    public string filePath;

    // 🔥 Event others can listen to
    public static Action<Texture2D> OnTextureReloaded;

    public void ReloadImage()
    {
        if (!File.Exists(filePath))
        {
            Debug.LogError("File not found: " + filePath);
            return;
        }

        byte[] data = File.ReadAllBytes(filePath);

        Texture2D tex = new Texture2D(2, 2, TextureFormat.RGBA32, false);
        tex.LoadImage(data);
        tex.filterMode = FilterMode.Point;

        if (image.sprite != null)
            Destroy(image.sprite);

        Sprite newSprite = Sprite.Create(
            tex,
            new Rect(0, 0, tex.width, tex.height),
            new Vector2(0.5f, 0.5f),
            100f
        );

        image.sprite = newSprite;

        image.SetAllDirty();
        image.canvasRenderer.SetTexture(null);

        // 🚀 Notify listeners (IMPORTANT PART)
        OnTextureReloaded?.Invoke(tex);
    }
}