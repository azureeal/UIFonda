using UnityEngine;

public class InventoryController : MonoBehaviour
{
    [SerializeField] InventoryView view;
    void Start()
    {

    }

    
    void Update()
    {
       
    }
    public void AddItem(Item item)
    {
        if (Inventory.Instance.IsInInventory(item))
        {
            return;
        }
        if (Inventory.Instance.AddItem(item, 1))
        {
            int i = Inventory.Instance.GetIndex(item);
            view.slots[i].sprite = Inventory.Instance.GetSlots()[i].item.icon;
        }
    }

    public void RemoveItem(int slotIndex)
    {
        view.ResetSlot(slotIndex);
        Inventory.Instance.RemoveOneFromSlot(slotIndex);
    }
}
