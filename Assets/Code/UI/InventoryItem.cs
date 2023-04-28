using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class InventoryItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] private ItemData _itemData;
    [SerializeField] private Image _itemDisplay;

    [HideInInspector]
    public Transform ParentAfterDrag;

    private RectTransform _childRectTransform;

    private Transform _parentTransform;

    public ItemData CurrentItemData => _itemData;
    private void OnValidate()
    {
        _itemDisplay = GetComponentInChildren<Image>();
        
        //FIXME: HACKY SOLUTION
        _childRectTransform = transform.GetChild(0).GetComponentInChildren<RectTransform>();
        EnsureInventoryItem();
    }

    private void Awake()
    {
        _itemDisplay = GetComponentInChildren<Image>();
        _childRectTransform = transform.GetChild(0).GetComponentInChildren<RectTransform>();
        
        //FIXME: Possible hacky solution?
        _parentTransform = GetComponentInParent<Canvas>().rootCanvas.transform;
    }

    private void EnsureInventoryItem()
    {
        if (_itemData == null)
        {
            _itemDisplay.sprite = null;
            _itemDisplay.color = new Color(1, 1, 1, 0);
            _childRectTransform.localPosition = Vector3.zero;
            return;
        }

        _itemDisplay.color = new Color(1, 1, 1, 1);
        _itemDisplay.sprite = _itemData.ItemSprite;
        _childRectTransform.localPosition = _itemData.DisplayOffset;
    }
    
    public void OnBeginDrag(PointerEventData eventData)
    {
        _itemDisplay.raycastTarget = false;
        ParentAfterDrag = transform.parent;
        
        transform.SetParent(_parentTransform);
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (_itemData == null) return;
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _itemDisplay.raycastTarget = true;
        transform.SetParent(ParentAfterDrag);
        
    }
}
