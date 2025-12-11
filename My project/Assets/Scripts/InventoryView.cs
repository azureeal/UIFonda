using UnityEngine;
using System.Collections.Generic;

public class InventoryView : MonoBehaviour
{
    public List<ItemSlotView> slotViews = new();

    public void SetSlot(int index, Sprite icon, System.Action onClick)
    {
        slotViews[index].SetIcon(icon);
        slotViews[index].SetOnClick(onClick);
    }

    public void ClearSlot(int index)
    {
        slotViews[index].Clear();
    }
}
