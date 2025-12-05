using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private float moveInput;
    public Transform spawnPoint;
    public GameObject consumablePrefab;
    private tableinteractable currentTable;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.LogError("PlayerMovement: No Rigidbody2D found on player.");
        }
    }

    void Update()
    {
        moveInput = Input.GetAxisRaw("Horizontal");

        if (currentTable != null && Input.GetKeyDown(KeyCode.E))
        {
            Instantiate(consumablePrefab, spawnPoint.position, Quaternion.identity);
            Debug.Log("Consumable spawned at " + spawnPoint.position);
        
        currentTable.SpawnConsumable();
            Debug.Log("Player pressed E - Spawn called on table.");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        tableinteractable table = other.GetComponent<tableinteractable>();
        if (other.CompareTag("Consume"))
        {
            Debug.Log("DRUG");
            {
                if (other.CompareTag("Player"))
                {
                    Destroy(consumablePrefab);
                }
            }
            }
            if (table != null)
        {
            currentTable = table;
            Debug.Log("Entered table range: " + other.name);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        tableinteractable table = other.GetComponent<tableinteractable>();
        if (table != null && table == currentTable)
        {
            currentTable = null;
            Debug.Log("Exited table range: " + other.name);
        }
    }

    void FixedUpdate()
    {
        if (rb != null)
            rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);
    }

}
