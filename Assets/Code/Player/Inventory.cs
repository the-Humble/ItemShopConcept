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
    
    private Dictionary<ItemType,PlayerBodypart> _bodyPartsToType = new Dictionary<ItemType, PlayerBodypart>();

    [SerializeField] private List<ItemData> _itemList;
    
    [SerializeField] private InventoryEvent OnUpdateInventory;
    public List<ItemData> ItemList => _itemList;
    public Dictionary<ItemType, PlayerBodypart> BodyPartsToType => _bodyPartsToType;

    [SerializeField] private int _gold = 500;

    private void Awake()
    {
        Init();
        _itemList.Add(_head.EquippedItemData);
        _itemList.Add(_chest.EquippedItemData);
        _itemList.Add(_legs.EquippedItemData);
        _itemList.Add(_shoes.EquippedItemData);
        _itemList.Add(_shield.EquippedItemData);
        _itemList.Add(_weapon.EquippedItemData);

        _bodyPartsToType.Add(ItemType.Head, _head);
        _bodyPartsToType.Add(ItemType.Chest, _chest);
        _bodyPartsToType.Add(ItemType.Legs, _legs);
        _bodyPartsToType.Add(ItemType.Shoes, _shoes);
        _bodyPartsToType.Add(ItemType.Shield, _shield);
        _bodyPartsToType.Add(ItemType.Weapon, _weapon);
        
        OnUpdateInventory.Invoke(this);
    }

    public void Init()
    {
        _head.Init();
        _legs.Init();
        _chest.Init();
        _shoes.Init();
        _weapon.Init();
        _shield.Init();
    }
    
    public bool TryBuyItem(ItemData itemData)
    {
        if (itemData.ItemCost >= _gold) return false;
        _gold -= itemData.ItemCost;
        _itemList.Add(Instantiate(itemData));
        TriggerUpdateEvent();
        return true;
    }

    public void EquipItem(ItemData itemData)
    {
        if(!_itemList.Contains(itemData) || itemData.IsEquipped) return;
        UnequipItem(itemData);
        _bodyPartsToType[itemData.ItemType].SetEquippedItemData(itemData);
        TriggerUpdateEvent();
    }

    public void UnequipItem(ItemData itemData)
    {
        if (!itemData.IsEquipped) return;
        _bodyPartsToType[itemData.ItemType].SetEquippedItemData(null);
        TriggerUpdateEvent();
    }

    public void SellItem(ItemData itemData)
    {
        _gold += itemData.ItemCost;
        _itemList.Remove(itemData);
        TriggerUpdateEvent();
    }

    public void TriggerUpdateEvent()
    {
        OnUpdateInventory.Invoke(this);
    }
}
