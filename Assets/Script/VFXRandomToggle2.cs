using UnityEngine;

public class VFXRandomToggle2 : MonoBehaviour
{
    public GameObject toggleVFX;

    [Range(0f, 100f)]
    public float chanceToTurnOn = 25f;

    public void TryRandomToggle()
    {
        if (toggleVFX == null) return;

        float roll = Random.Range(0f, 100f);

        if (roll <= chanceToTurnOn)
        {
            SetVFX(true);   // 25% chance
        }
        else
        {
            SetVFX(false);  // 75% chance
        }
    }

    public void SetVFX(bool state)
    {
        toggleVFX.SetActive(state);
    }
}