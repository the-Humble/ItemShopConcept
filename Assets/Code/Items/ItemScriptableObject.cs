using System;using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    None,
    Head,
    Legs,
    Chest,
    Shield,
    Weapon
}

[CreateAssetMenu(menuName = "ScriptableObjects/ItemData", fileName = "NewItemData")]
public class ItemScriptableObject : ScriptableObject
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
    
    public Sprite ItemSprite => _sprite;
    public string ItemName => _name;
    public string ItemDescription => _description;
    public ItemType ItemType => _itemType;
    public int ItemCost => _cost;
}
