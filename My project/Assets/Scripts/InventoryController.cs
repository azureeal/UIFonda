using UnityEngine;

public class InventoryController : MonoBehaviour
{
    [SerializeField] InventoryView view;
    Inventory inventory;
    void Start()
    {
        inventory = new();
    }


    void Update()
    {
        
    }
}
