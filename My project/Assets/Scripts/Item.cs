// Item.cs
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    public string itemName;
    public int maxStack = 1;
    public GameObject prefab;
    public Sprite icon;

    public virtual void UseItem()
    {
        Debug.Log("Using item: " + itemName);
    }
}