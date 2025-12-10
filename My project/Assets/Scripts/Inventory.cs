// Inventory.cs
using System.Collections;
using UnityEngine;
using static UnityEditor.Progress;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance;

    [SerializeField] private InventorySlot[] slots = new InventorySlot[4];

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        InitializeSlots();
    }
    public InventorySlot[] GetSlots()
    {
        return slots;
    }
    private void InitializeSlots()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i] == null)
                slots[i] = new InventorySlot();
        }
    }
    public int GetIndex(Item item)
    {
        if (item == null) return -1;

        for (int i = 0; i < slots.Length; i++)
        {
            if (!slots[i].IsEmpty && slots[i].item == item)
            {
                return i;
            }
        }

        return -1;
    }

    public void RemoveOneFromSlot(int slotIndex)
    {
        if (slotIndex < 0 || slotIndex >= slots.Length) return;

        slots[slotIndex].quantity--;
        if (slots[slotIndex].quantity <= 0)
        {
            slots[slotIndex].Clear();
        }
    }

    public bool AddItem(Item item, int amount = 1)
    {
        // Essayer d'ajouter � un slot existant
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].CanAddItem(item))
            {
                int spaceLeft = item.maxStack - slots[i].quantity;
                int toAdd = Mathf.Min(amount, spaceLeft);
                slots[i].quantity += toAdd;
                return true;
            }
        }

        // Chercher un slot vide
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].IsEmpty)
            {
                slots[i].SetItem(item, amount);
                return true;
            }
        }

        Debug.Log("Inventory full!");
        return false;
    }
    public int GetOccupiedSlotCount()
    {
        int count = 0;
        for (int i = 0; i < slots.Length; i++)
        {
            if (!slots[i].IsEmpty)
                count++;
        }
        return count;
    }
    public bool IsInInventory(Item item)
    {
        return GetIndex(item) != -1;
    }

}