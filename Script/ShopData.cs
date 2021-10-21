using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopData : MonoBehaviour
{
    public List<Item> stocks = new List<Item>();
    void Start()
    {
        //아이템추가
        stocks.Add(ItemDatabase.instance.itemDB[0]);
        stocks.Add(ItemDatabase.instance.itemDB[1]);

    }

}
