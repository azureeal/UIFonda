// Inventory.cs
using System.Collections;
using UnityEngine;
using static UnityEditor.Progress;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance;

    [SerializeField] private InventorySlot[] slots = new InventorySlot[4];
    [SerializeField] private KeyCode[] slotKeys;
    private int currentSelectedSlot = -1;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        InitializeSlots();
        InitializeKeys();
    }

    private void InitializeSlots()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i] == null)
                slots[i] = new InventorySlot();
        }
    }

    private void InitializeKeys()
    {
        if (slotKeys == null || slotKeys.Length == 0)
        {
            slotKeys = new KeyCode[] {
                KeyCode.Alpha6,
                KeyCode.Alpha7,
                KeyCode.Alpha8,
                KeyCode.Alpha9
            };
        }
    }

    private void Update()
    {
        HandleSlotInput();
    }

    private void HandleSlotInput()
    {
        for (int i = 0; i < slotKeys.Length; i++)
        {
            if (Input.GetKeyDown(slotKeys[i]))
            {
                if (currentSelectedSlot == i)
                {
                    DeactivateCurrentSlot();
                }
                else
                {
                    DeactivateCurrentSlot();
                    ActivateSlot(i);
                }
                break;
            }
        }

        if (currentSelectedSlot != -1 && (Input.GetKeyDown(KeyCode.Escape) || Input.GetMouseButtonDown(1)))
        {
            DeactivateCurrentSlot();
        }
    }

    private void ActivateSlot(int slotIndex)
    {
        if (slotIndex < 0 || slotIndex >= slots.Length) return;
        if (slots[slotIndex].IsEmpty) return;

        currentSelectedSlot = slotIndex;
        Item item = slots[slotIndex].item;
        RemoveOneFromSlot(slotIndex);
        currentSelectedSlot = -1;
    }

    private void DeactivateCurrentSlot()
    {
        if (currentSelectedSlot != -1)
        {
            currentSelectedSlot = -1;
        }
    }

    public void ConfirmPlacement(Vector3 position, Quaternion rotation)
    {
        if (currentSelectedSlot != -1)
        {
            Instantiate(slots[currentSelectedSlot].item.prefab, position, rotation);
            RemoveOneFromSlot(currentSelectedSlot);
            DeactivateCurrentSlot();
        }
    }

    private void RemoveOneFromSlot(int slotIndex)
    {
        if (slotIndex < 0 || slotIndex >= slots.Length) return;

        slots[slotIndex].quantity--;
        if (slots[slotIndex].quantity <= 0)
        {
            slots[slotIndex].Clear();
        }

        // Mettre � jour l'UI ici si n�cessaire
        UpdateUI();
    }

    public bool AddItem(Item item, int amount = 1)
    {
        // Essayer d'ajouter � un slot existant
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].CanAddItem(item))
            {
                int spaceLeft = item.maxStack - slots[i].quantity;
                int toAdd = Mathf.Min(amount, spaceLeft);
                slots[i].quantity += toAdd;
                UpdateUI();
                return true;
            }
        }

        // Chercher un slot vide
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].IsEmpty)
            {
                slots[i].SetItem(item, amount);
                UpdateUI();
                return true;
            }
        }

        Debug.Log("Inventory full!");
        return false;
    }
    private void UpdateUI()
    {
        // Ici vous pouvez mettre � jour votre UI d'inventaire
        // Par exemple : 
        // for (int i = 0; i < slots.Length; i++)
        // {
        //     inventoryUI.UpdateSlot(i, slots[i].item, slots[i].quantity);
        // }
    }

}