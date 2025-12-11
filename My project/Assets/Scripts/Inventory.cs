using UnityEngine;
using System.Collections.Generic;
public class Inventory
{

    [SerializeField] private List<InventorySlot> slots;

    public Inventory(int slotCount)
    {
        slots = new List<InventorySlot>(slotCount);
        InitializeSlots();
    }
    public new List<InventorySlot> GetSlots()
    {
        return slots;
    }
    private void InitializeSlots()
    {
        for (int i = 0; i < slots.Capacity; i++)
        {
            slots.Add(new InventorySlot());
        }
    }
    public int GetIndex(Item item)
    {
        foreach (InventorySlot slot in slots)
        {
            if (item == slot.item)
            {
                return slots.IndexOf(slot);
            }
        }
        return -1;
    }

    public void RemoveOneFromSlot(int slotIndex)
    {
        if (slotIndex < 0 || slotIndex >= slots.Count) return;

        slots[slotIndex].quantity--;

        if (slots[slotIndex].quantity <= 0)
        {
            slots.RemoveAt(slotIndex);
        }
    }


    public bool AddItem(Item item, int amount = 1)
    {
        for (int i = 0; i < slots.Count; i++)
        {
            if (slots[i].CanAddItem(item))
            {
                int spaceLeft = item.maxStack - slots[i].quantity;
                int toAdd = Mathf.Min(amount, spaceLeft);
                slots[i].quantity += toAdd;
                return true;
            }
        }

        for (int i = 0; i < slots.Count; i++)
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
        for (int i = 0; i < slots.Count; i++)
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