using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPedestal : MonoBehaviour
{
    [SerializeField] private ItemData _itemData;
    [SerializeField] private bool _isEmpty;

    [SerializeField] private GameObject _itemDisplay;

    public bool IsEmpty
    {
        get { return _isEmpty; }

        set
        {
            if (_isEmpty == value) return;
            _isEmpty = value;
            DisplayItem(_isEmpty);
        }
    }

    private void OnValidate()
    {
        EnsureItemDisplay();
    }

    private void EnsureItemDisplay()
    {
        var itemDisplayRenderer = _itemDisplay.GetComponent<SpriteRenderer>();

        if (_itemData == null)
        {
            IsEmpty = true;
            return;
        }
        
        itemDisplayRenderer.sprite = _itemData.ItemSprite;
        name = _itemData.ItemName;
        IsEmpty = false;
    }

    private void DisplayItem(bool shouldDisplay)
    {
        _itemDisplay.SetActive(!_isEmpty);
    }
}
