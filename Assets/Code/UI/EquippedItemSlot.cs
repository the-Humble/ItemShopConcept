using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EquippedItemSlot : ItemSlot
{
    [SerializeField] private ItemType _acceptedItemType; 
    public override void OnDrop(PointerEventData eventData)
    {
        InventoryItem item = eventData.pointerDrag.GetComponent<InventoryItem>();
        if (_acceptedItemType != item.CurrentItemData.ItemType) return;
        
        base.OnDrop(eventData);
    }
}
