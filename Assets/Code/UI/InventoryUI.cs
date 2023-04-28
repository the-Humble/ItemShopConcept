using System;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private ItemSlot[] _itemSlots = new ItemSlot[25];
    
    [SerializeField] private EquippedItemSlot _headSlot;
    [SerializeField] private EquippedItemSlot _chestSlot;
    [SerializeField] private EquippedItemSlot _legSlot;
    [SerializeField] private EquippedItemSlot _shoeSlot;
    [SerializeField] private EquippedItemSlot _shieldSlot;
    [SerializeField] private EquippedItemSlot _weaponSlot;
    
    private List<GameObject> _temporaryGO = new List<GameObject>();

    [SerializeField] private GameObject _inventoryItemPrefab;

    public void UpdateItemSlots(Inventory inventory)
    {
        foreach (GameObject go in _temporaryGO)
        {
            if(go!=null) Destroy(go);
        }
        _temporaryGO.Clear();
        
        int counterSlots = 0;
        int counterList = 0;
        while (counterList < inventory.ItemList.Count && counterSlots < _itemSlots.Length)
        {
            var item = inventory.ItemList[counterList];
            if (item != null)
            {
                if (!item.IsEquipped)
                {
                    var newItem = Instantiate(_inventoryItemPrefab, _itemSlots[counterSlots].transform);
                    newItem.GetComponent<InventoryItem>().Init(item);
                    _temporaryGO.Add(newItem);
                    counterSlots++;
                }
                else
                {
                    EquippedItemSlot destinationSlot = null;
                    switch (item.ItemType)
                    {
                        case ItemType.Head:
                            destinationSlot = _headSlot;
                            break;
                        case ItemType.Legs:
                            destinationSlot = _legSlot;
                            break;
                        case ItemType.Shoes:
                            destinationSlot = _shoeSlot;
                            break;
                        case ItemType.Chest:
                            destinationSlot = _chestSlot;
                            break;
                        case ItemType.Shield:
                            destinationSlot = _shieldSlot;
                            break;
                        case ItemType.Weapon:
                            destinationSlot = _weaponSlot;
                            break;
                    }
                    var newItem = Instantiate(_inventoryItemPrefab, destinationSlot.transform);
                    newItem.GetComponent<InventoryItem>().Init(item);
                    destinationSlot.HasEquipped = true;
                    _temporaryGO.Add(newItem);
                }
            }
            counterList++;
        }
    }

    public void ToggleInventoryScreen()
    {
        gameObject.SetActive(!gameObject.activeInHierarchy);
        Time.timeScale = gameObject.activeInHierarchy ? 0 : 1;
    }

}
