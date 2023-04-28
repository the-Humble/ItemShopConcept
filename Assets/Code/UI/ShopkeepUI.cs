using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopkeepUI : MenuScreen
{
    public override void UpdateItemSlots(Inventory inventory)
    {
        foreach (GameObject go in _temporaryGO)
        {
            if(go!=null) Destroy(go);
        }
        _temporaryGO.Clear();
        
        int counterSlots = 0;
        int counterList = 0;
        while (counterList < inventory.ItemList.Count && counterSlots < _itemSlots.Length)
        {
            var item = inventory.ItemList[counterList];
            if (item != null)
            {
                if (!item.IsEquipped)
                {
                    var newItem = Instantiate(_inventoryItemPrefab, _itemSlots[counterSlots].transform);
                    newItem.GetComponent<InventoryItem>().Init(item);
                    _temporaryGO.Add(newItem);
                    counterSlots++;
                }
            }
            counterList++;
        }
    }
    
}
