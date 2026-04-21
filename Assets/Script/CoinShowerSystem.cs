using UnityEngine;

public class CoinShowerSystem : MonoBehaviour
{
    public Texture2D noiseTexture;
    public GameObject prefab;

    public int width = 100;
    public int height = 100;
    public float scale = 10f;
    public float threshold = 0.5f;

    void Start()
    {
        SpawnObjects();
    }

    void SpawnObjects()
    {
        for (int x = 0; x < width; x++)
        {
            for (int z = 0; z < height; z++)
            {
                float u = (float)x / width;
                float v = (float)z / height;

                float noiseValue = noiseTexture.GetPixelBilinear(u, v).grayscale;

                if (noiseValue > threshold)
                {
                    Vector3 position = new Vector3(x * scale, 0, z * scale);
                    Instantiate(prefab, position, Quaternion.identity, transform);
                }
            }
        }
    }
}