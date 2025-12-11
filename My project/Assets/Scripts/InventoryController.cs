using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    [SerializeField] private InventoryView view;
    [SerializeField] private GameObject slotPrefab;
    [SerializeField] private Transform content;

    private Inventory inventory;

    void Start()
    {
        inventory = new Inventory(20);
        BuildSlotViews(inventory.GetSlots().Count);
        RefreshView();
    }

    void BuildSlotViews(int slotCount)
    {
        for (int i = 0; i < slotCount; i++)
        {
            GameObject go = Instantiate(slotPrefab, content);
            ItemSlotView slotView = go.GetComponent<ItemSlotView>();
            view.slotViews.Add(slotView);
        }
    }

    public void AddItem(Item item)
    {
        if (inventory.AddItem(item))
        {
            RefreshView();
        }
    }

    public void RemoveItem(int index)
    {
        inventory.RemoveOneFromSlot(index);
        RefreshView();
    }

    void RefreshView()
    {
        List<InventorySlot> slots = inventory.GetSlots();

        for (int i = 0; i < view.slotViews.Count; i++)
        {
            if (i < slots.Count && !slots[i].IsEmpty)
            {
                var item = slots[i].item;
                view.SetSlot(
                    i,
                    item.icon,
                    () => RemoveItem(inventory.GetIndex(item))
                );
            }
            else
            {
                view.ClearSlot(i);
            }
        }
    }
}
