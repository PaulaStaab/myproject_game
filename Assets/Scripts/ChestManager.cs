using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class ChestManager: MonoBehaviour                              //KI generierter Code
{
    [SerializeField] private GameObject inventory;

    private InventoryManager inventoryManager;

    // Sprite for the closed chest
    public Sprite chest;

    // Sprite for the opened chest
    public Sprite openchest;

    // Sprite for the sword
    [SerializeField] private InventoryItemData sword;

    //Sprite for the shield
    [SerializeField] private InventoryItemData shield;

    // Reference to the SpriteRenderer component
    private SpriteRenderer spriteRenderer;

    // Is the player close enough to interact with the chest?
    [SerializeField] private bool isPlayerNearby = false;

    // Has the chest already been opened?
    private bool isOpen = false;

    void Start()
    {
        inventoryManager = inventory.GetComponent<InventoryManager>();

        // Get the SpriteRenderer attached to this object
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Set the initial chest sprite to the closed version
        spriteRenderer.sprite = chest;
    }
   
    public void OpenChest(CallbackContext ctx)
    {
        if (!ctx.canceled) return;
        
        // Change the sprite to the open chest
        spriteRenderer.sprite = openchest;

        // Mark the chest as opened
        isOpen = true;

        // Print to console (can be replaced with actual item logic)
        Debug.Log("Chest opened! You found a sword and a shield :)");

        inventoryManager.AddItem(sword);
        inventoryManager.AddItem(shield);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Funktion wird aufgerufen");  
        // If the player enters the chest's trigger zone
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        // If the player exits the chest's trigger zone
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = false;
        }
    }
}
