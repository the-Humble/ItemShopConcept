using System;using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    None,
    Head,
    Legs,
    Shoes,
    Chest,
    Shield,
    Weapon
}

[CreateAssetMenu(menuName = "ScriptableObjects/ItemData", fileName = "NewItemData")]
public class ItemData : ScriptableObject
{
    [SerializeField] 
    private Sprite _sprite;
    
    [SerializeField] 
    private string _name;
    
    [SerializeField] 
    private ItemType _itemType;
    
    [TextArea]
    [SerializeField] 
    private string _description;
    
    [SerializeField] 
    private int _cost;
    
    public bool IsEquipped { get; set; }

    public Sprite ItemSprite => _sprite;
    public string ItemName => _name;
    public string ItemDescription => _description;
    public ItemType ItemType => _itemType;
    public int ItemCost => _cost;
}
