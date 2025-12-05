using UnityEngine;

public class tableinteractable : MonoBehaviour
{
    public GameObject consumablePrefab;  // assign in Inspector
    public Transform spawnPoint;         // empty GameObject for spawn location

    private bool hasDropped = false;     // optional, prevents infinite drops

    public void SpawnConsumable()
    {
        if (consumablePrefab == null || spawnPoint == null)
        {
            Debug.LogWarning("SpawnConsumable: missing prefab or spawnPoint.");
            return;
        }
        Instantiate(consumablePrefab, spawnPoint.position, Quaternion.identity);
        Debug.Log("Consumable spawned at " + spawnPoint.position);
    }

}