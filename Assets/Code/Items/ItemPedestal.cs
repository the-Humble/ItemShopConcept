using System;
using System.Collections;
using System.Collections.Generic;
using Code.Core;
using TMPro;
using UnityEditor;
using UnityEngine;

[RequireComponent(typeof(ColliderCallbacks))]
public class ItemPedestal : MonoBehaviour, IInteractable
{
    [SerializeField] private ItemData _itemData;
    [SerializeField] private bool _isEmpty;

    [SerializeField] private GameObject _itemDisplay;

    [SerializeField] private RectTransform _canvas;

    [SerializeField] private TextMeshProUGUI _nameDisplay;
    [SerializeField] private TextMeshProUGUI _descriptionDisplay;
    [SerializeField] private TextMeshProUGUI _costDisplay;

    private static ItemPedestal ActiveDisplay;
    
    private ColliderCallbacks _colliderCallbacks;
    
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

    private void OnEnable()
    {
        _colliderCallbacks.OnTriggerStayEvent += DisplayUI;
        _colliderCallbacks.OnTriggerExitEvent += HideUI;
    }
    private void OnDisable()
    {
        _colliderCallbacks.OnTriggerStayEvent -= DisplayUI;
        _colliderCallbacks.OnTriggerExitEvent -= HideUI;
    }

    private void Awake()
    {
        _colliderCallbacks = GetComponent<ColliderCallbacks>();
        InitUI();
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
            HideUI(null);
        }
    }

    private void InitUI()
    {
        _nameDisplay.text = _itemData.ItemName;
        _descriptionDisplay.text = _itemData.ItemDescription;
        _costDisplay.text = _itemData.ItemCost.ToString();
    }

    public void DisplayUI(Collider2D other)
    {
        if (ActiveDisplay != null || IsEmpty) return;
        ActiveDisplay = this;
        LeanTween.scale(_canvas, Vector3.one, 0.1f).setEaseOutElastic();
    }
    public void HideUI(Collider2D other)
    {
        if (ActiveDisplay != this) return;
        ActiveDisplay = null;
        LeanTween.scale(_canvas, Vector3.zero, 0.1f).setEaseInElastic();
    }
}
