using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Item
{
    public enum ItemType
    {
        hppostion,
        manapostion,
    }

    public ItemType itemtype;
    public string itemName;
    public int ItemCost;
    public int ItemSell;
    public string iteminstruction;
    public Sprite itemImage;
    public List<ItemEffect> efts;

    public bool Use()
    {
        bool isUsed = false;
        foreach (ItemEffect eft in efts)
        {
            isUsed = eft.ExecuteRole();
        }
        isUsed = true;

        return isUsed;
    }
}
