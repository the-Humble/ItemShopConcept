using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [Header("Body Parts")]
    [SerializeField] private PlayerBodypart _head;
    [SerializeField] private PlayerBodypart _chest;
    [SerializeField] private PlayerBodypart _legs;
    [SerializeField] private PlayerBodypart _shoes;
    [SerializeField] private PlayerBodypart _shield;
    [SerializeField] private PlayerBodypart _weapon;
    
    [SerializeField] private List<ItemData> _itemList;
    public List<ItemData> ItemList => _itemList;

    [SerializeField] private int _gold = 500;

    private void Awake()
    {
        _itemList.Add(_head.EquippedItemData);
        _itemList.Add(_chest.EquippedItemData);
        _itemList.Add(_legs.EquippedItemData);
        _itemList.Add(_shoes.EquippedItemData);
        _itemList.Add(_shield.EquippedItemData);
        _itemList.Add(_weapon.EquippedItemData);
        
        _itemList.RemoveAll(item => item == null);
    }

    public bool TryBuyItem(ItemData itemData)
    {
        if (itemData.ItemCost >= _gold) return false;
        _gold -= itemData.ItemCost;
        _itemList.Add(Instantiate(itemData));
        return true;
    }

    public void EquipItem(ItemData itemData)
    {
        if(!_itemList.Contains(itemData)) return;
        switch (itemData.ItemType)
        {
            case ItemType.Head:
                _head.SetEquippedItemData(itemData);
                break;
            case ItemType.Legs:
                _legs.SetEquippedItemData(itemData);
                break;
            case ItemType.Shoes:
                _shoes.SetEquippedItemData(itemData);
                break;
            case ItemType.Chest:
                _chest.SetEquippedItemData(itemData);
                break;
            case ItemType.Shield:
                _shield.SetEquippedItemData(itemData);
                break;
            case ItemType.Weapon:
                _weapon.SetEquippedItemData(itemData);
                break;
            default:
                return;
        }
    }

    public void UnequipItem(ItemType itemType)
    {
        switch (itemType)
        {
            case ItemType.Head:
                _head.SetEquippedItemData(null);
                break;
            case ItemType.Legs:
                _legs.SetEquippedItemData(null);
                break;
            case ItemType.Shoes:
                _shoes.SetEquippedItemData(null);
                break;
            case ItemType.Chest:
                _chest.SetEquippedItemData(null);
                break;
            case ItemType.Shield:
                _shield.SetEquippedItemData(null);
                break;
            case ItemType.Weapon:
                _weapon.SetEquippedItemData(null);
                break;
            default:
                return;
        }
    }

    public void SellItem(ItemData itemData)
    {
        _gold += itemData.ItemCost;
        _itemList.Remove(itemData);
    }
}
