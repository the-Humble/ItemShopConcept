using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class PlayerBodypart : MonoBehaviour
{
    [SerializeField] private ItemData _equippedItemData;
    [SerializeField] private ItemType _itemType;
    private SpriteRenderer _itemDisplaySprite;

    private void Awake()
    {
        EnsureEquippedItem();
    }

    private void OnValidate()
    {
        EnsureEquippedItem();
    }

    private void EnsureEquippedItem()
    {
        _itemDisplaySprite = GetComponent<SpriteRenderer>();

        if (_equippedItemData == null)
        {
            _itemDisplaySprite.sprite = null;
            return;
        }

        _itemDisplaySprite.sprite = _equippedItemData.ItemSprite;
    }
}
