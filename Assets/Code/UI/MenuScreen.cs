using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MenuScreen : MonoBehaviour
{
    public static MenuScreen ActiveScreen;
    
    [SerializeField] protected ItemSlot[] _itemSlots = new ItemSlot[25];
    
    protected List<GameObject> _temporaryGO = new List<GameObject>();

    [SerializeField] protected GameObject _inventoryItemPrefab;

    public virtual void UpdateItemSlots(Inventory iventory)
    { }

    public void ToggleMenuScreen()
    {
        if (ActiveScreen != this)
        {
            if (ActiveScreen != null) return;
        }
        gameObject.SetActive(!gameObject.activeInHierarchy);
        Time.timeScale = gameObject.activeInHierarchy ? 0 : 1;
        ActiveScreen = gameObject.activeInHierarchy ? this : null;
    }
}
