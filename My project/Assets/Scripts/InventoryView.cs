using UnityEngine;
using UnityEngine.UI;

public class InventoryView : MonoBehaviour
{
    public Image[] slots;
    public Sprite[] placements;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void SetItem(Sprite item, int index)
    {
        slots[index].sprite = item;
    }
    public void ResetSlot(int index) 
    {
        slots[index].sprite = placements[index];
    }
}
