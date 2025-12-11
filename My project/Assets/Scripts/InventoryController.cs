using UnityEngine;
using System.Collections.Generic;

public class InventoryController : MonoBehaviour
{
    [SerializeField] private GameObject slotPrefab;
    [SerializeField] private Transform content;

    private Inventory inventory;
    private List<ItemSlotController> slotControllers = new();

    void Start()
    {
        inventory = new Inventory(20);
        BuildSlotControllers(inventory.GetSlots().Count);
        RefreshUI();
    }

    void BuildSlotControllers(int count)
    {
        for (int i = 0; i < count; i++)
        {
            GameObject go = Instantiate(slotPrefab, content);
            var controller = go.GetComponent<ItemSlotController>();
            slotControllers.Add(controller);
        }
    }

    public void AddItem(Item item)
    {
        if (inventory.AddItem(item))
            RefreshUI();
    }

    public void RemoveItem(int index)
    {
        inventory.RemoveOneFromSlot(index);
        RefreshUI();
    }

    private void RefreshUI()
    {
        List<InventorySlot> slots = inventory.GetSlots();

        for (int i = 0; i < slotControllers.Count; i++)
        {
            if (i < slots.Count && !slots[i].IsEmpty)
            {
                int capturedIndex = i;
                var slot = slots[i];

                slotControllers[i].SetSlot(
                    slot.item.icon,
                    () => RemoveItem(inventory.GetIndex(slot.item))
                );
            }
            else
            {
                slotControllers[i].ClearSlot();
            }
        }
    }
}
