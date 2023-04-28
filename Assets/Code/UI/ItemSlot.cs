using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(GridLayoutGroup))]
public class ItemSlot : MonoBehaviour, IDropHandler
{
    [SerializeField] private ItemDataEvent OnItemUnequipped;
    public virtual void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount == 0)
        {
            InventoryItem item = eventData.pointerDrag.GetComponent<InventoryItem>();
            item.ParentAfterDrag = transform;
            if (item.CurrentItemData.IsEquipped)
            {
                OnItemUnequipped.Invoke(item.CurrentItemData);
            }
        }
    }
}
