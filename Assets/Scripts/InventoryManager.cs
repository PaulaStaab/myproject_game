using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryManager : MonoBehaviour
{
    // Parent container holding all inventory slot GameObjects
    [SerializeField] private Transform SlotsPanel;

    // Prefab to instantiate new inventory slots
    [SerializeField] private GameObject slotPrefab;

    // List of all inventory slots (both used and free)
    [SerializeField] private List<GameObject> inventorySlots = new List<GameObject>();

    // List of currently free (empty) inventory slots
    [SerializeField] private List<GameObject> FreeInventorySlots = new List<GameObject>();

    // The UI panel to toggle
    [SerializeField] private GameObject inventoryPanel;


    private SlotsManager CurrentSlot; // Reference to the currently selected slot
    private void Start()
    {
        // Find and store all existing slots that are children of the SlotsPanel
        foreach (Transform slot in SlotsPanel)
        {
            inventorySlots.Add(slot.gameObject);
        }

        // Populate the list of free slots
        GetFreeSlots();
    }

    // Adds an item to the first available free slot
    public void AddItem(InventoryItemData item)
    {
        GetFreeSlots(); // Update the list of free slots

        if (FreeInventorySlots.Count > 0)
        {
            // Get the first free slot
            GameObject freeSlot = FreeInventorySlots[0];

            // Access the slot's SlotsManager to insert the item
            SlotsManager sM = freeSlot.GetComponent<SlotsManager>();
            sM.SetItem(item); // Set the item (e.g., a shield)

            // Remove the slot from the free list since it's now used
            FreeInventorySlots.RemoveAt(0);
        }
        else
        {
            Debug.Log("No free slot available!");
        }
    }

    // Checks which slots are currently free
    private void GetFreeSlots()
    {
        // Clear previous data
        FreeInventorySlots.Clear();

        // Loop through all slots and find the free ones
        foreach (Transform slot in SlotsPanel)
        {
            SlotsManager sM = slot.GetComponent<SlotsManager>();
            if (sM.SlotFree == true)
            {
                FreeInventorySlots.Add(slot.gameObject);
            }
        }
    }

    // Dynamically creates a new inventory slot
    public void CreateNewSlot()
    {
        // Instantiate a new slot from the prefab and add it to the SlotsPanel
        GameObject newSlot = Instantiate(slotPrefab, SlotsPanel);

        // Add the new slot to the full inventory list
        inventorySlots.Add(newSlot);

        // Refresh the list of free slots
        GetFreeSlots();
    }

    public void ToggleInventory()
    {
        bool isNowOpen = !inventoryPanel.activeSelf;
        inventoryPanel.SetActive(isNowOpen); // Show or hide the inventory panel

        if (isNowOpen)
        {
            // Pause game while inventory is open
            Time.timeScale = 0f;
        }
        else
        {
            // Resume game and reset UI state
            Time.timeScale = 1f;
            CurrentSlot = null; // Clear selected slot
        }
    }
}

//    private void Update()
//    {
//        if (Input.GetKeyDown(KeyCode.I))
//        {
//            OpenCloseInventory();
//        }
//    }

//}