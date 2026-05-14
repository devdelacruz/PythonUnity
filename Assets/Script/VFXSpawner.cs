using UnityEngine;

public class VFXSpawner : MonoBehaviour
{
    [Header("References")]
    public GameObject vfxPrefab;
    public Transform target;

    [Header("Local Position Inside Object")]
    public Vector3 localOffset = Vector3.zero;

    [Header("Optional")]
    public bool parentToTarget = true;
    public float destroyAfter = 2f;

    public void SpawnVFX()
    {
        // Convert local position to world position
        Vector3 spawnPosition = target.TransformPoint(localOffset);

        GameObject vfx = Instantiate(
            vfxPrefab,
            spawnPosition,
            Quaternion.identity
        );

        // Make VFX follow the object
        if (parentToTarget)
        {
            vfx.transform.SetParent(target);
        }

        // Auto destroy
        Destroy(vfx, destroyAfter);
    }
}