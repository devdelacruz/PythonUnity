using TMPro;
using UnityEngine;

public class FloatingText : MonoBehaviour
{
    public TextMeshProUGUI textMesh;

    public float moveSpeed = 60f;
    public float lifeTime = 1f;

    private float timer;
    private CanvasGroup canvasGroup;

    void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void Show(string text)
    {
        textMesh.text = text;
        timer = lifeTime;

        if (canvasGroup != null)
            canvasGroup.alpha = 1f;
    }

    void Update()
    {
        transform.position += Vector3.up * moveSpeed * Time.deltaTime;

        timer -= Time.deltaTime;

        if (canvasGroup != null)
        {
            canvasGroup.alpha = timer / lifeTime;
        }

        if (timer <= 0f)
        {
            FloatingTextSpawner.Instance.ReturnToPool(this);
        }
    }
}