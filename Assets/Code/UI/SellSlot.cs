using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class SellSlot : MonoBehaviour, IDropHandler
{
    [SerializeField] private ItemDataEvent OnItemSoldEvent;

    public virtual void OnDrop(PointerEventData eventData)
    {
        InventoryItem item = eventData.pointerDrag.GetComponent<InventoryItem>();
        if (item.CurrentItemData.IsEquipped) return;
        OnItemSoldEvent.Invoke(item.CurrentItemData);
    }
}
