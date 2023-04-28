using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EquippedItemSlot : ItemSlot
{
    [SerializeField] private ItemType _acceptedItemType;
    [SerializeField] private ItemDataEvent OnItemEquipped;
    [SerializeField] private Image _previewIcon;

    private bool _hasEquipped = false;

    public bool HasEquipped
    {
        get => _hasEquipped;
        set
        {
            _hasEquipped = value;
            _previewIcon.gameObject.SetActive(!_hasEquipped);
        }
    }

    public override void OnDrop(PointerEventData eventData)
    {
        InventoryItem item = eventData.pointerDrag.GetComponent<InventoryItem>();
        if (_acceptedItemType != item.CurrentItemData.ItemType) return;
        base.OnDrop(eventData);
        OnItemEquipped.Invoke(item.CurrentItemData);
    }

    public void UnequipFromSlot(ItemData itemData)
    {
        if (itemData.ItemType == _acceptedItemType)
        {
            HasEquipped = false;
        }
    }
}
