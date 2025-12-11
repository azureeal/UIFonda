// InventorySlot.cs
using System;
using UnityEngine;

[Serializable]
public class InventorySlot
{
    public Item item;
    public int quantity;

    public bool IsEmpty => item == null || quantity <= 0;
    public bool CanAddItem(Item newItem) => !IsEmpty && item == newItem && quantity < item.maxStack;

    public void Clear()
    {
        item = null;
        quantity = 0;
    }

    public void SetItem(Item newItem, int amount)
    {
        item = newItem;
        quantity = amount;
    }
}