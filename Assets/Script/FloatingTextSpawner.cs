using System.Collections.Generic;
using UnityEngine;

public class FloatingTextSpawner : MonoBehaviour
{
    public static FloatingTextSpawner Instance;

    public GameObject floatingTextPrefab;
    public Canvas canvas;

    public int poolSize = 20;

    private Queue<FloatingText> pool = new Queue<FloatingText>();

    void Awake()
    {
        Instance = this;

        // Pre-create pool
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(floatingTextPrefab, canvas.transform);
            obj.SetActive(false);

            pool.Enqueue(obj.GetComponent<FloatingText>());
        }
    }

    public void ShowText(string message, Vector3 screenPos)
    {
        FloatingText ft = GetFromPool();

        ft.transform.position = screenPos + new Vector3(
            Random.Range(-20f, 20f),
            Random.Range(-10f, 10f),
            0f
        );

        ft.gameObject.SetActive(true);
        ft.Show(message);
    }

    public FloatingText GetFromPool()
    {
        if (pool.Count > 0)
        {
            return pool.Dequeue();
        }

        // fallback if pool empty
        GameObject obj = Instantiate(floatingTextPrefab, canvas.transform);
        return obj.GetComponent<FloatingText>();
    }

    public void ReturnToPool(FloatingText ft)
    {
        ft.gameObject.SetActive(false);
        pool.Enqueue(ft);
    }
}