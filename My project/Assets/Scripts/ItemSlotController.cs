using UnityEngine;

public class ItemSlotController : MonoBehaviour
{
    public ItemSlotView view;

    public void SetSlot(Sprite icon, System.Action onClick)
    {
        view.SetIcon(icon);
        view.SetOnClick(onClick);
    }

    public void ClearSlot()
    {
        view.Clear();
    }
}
