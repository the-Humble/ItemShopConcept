using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ItemPedestal : MonoBehaviour, IInteractable
{
    [SerializeField] private ItemData _itemData;
    [SerializeField] private bool _isEmpty;

    [SerializeField] private GameObject _itemDisplay;

    private string _labelName;
    private Vector2 _labelOffset = new Vector2(-0.5f, -.2f); 

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
            _labelName = "Empty Pedestal";
            return;
        }
        
        itemDisplayRenderer.sprite = _itemData.ItemSprite;
        _labelName = name = _itemData.ItemName;
        IsEmpty = false;
    }

    private void DisplayItem(bool shouldDisplay)
    {
        _itemDisplay.SetActive(!_isEmpty);
    }

    public string InteractablePrompt { get; }
    public void Interact(Interactor interactor)
    {
        if (IsEmpty) return;
        Inventory inventory = interactor.GetComponent<Player>().PlayerInventory;
        if(inventory.TryBuyItem(_itemData))
        {
            IsEmpty = true;
        }
    }
}
