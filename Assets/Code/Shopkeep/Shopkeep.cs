using System.Collections;
using System.Collections.Generic;
using Code.Core;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Shopkeep : MonoBehaviour, IInteractable
{

    [SerializeField] private ShopkeepUI _shopkeepUI;
    public void Interact(Interactor interactor)
    {
        Inventory inventory = interactor.GetComponent<Player>().PlayerInventory;
        _shopkeepUI.UpdateItemSlots(inventory);
        _shopkeepUI.ToggleMenuScreen();
    }
}
