using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Slot : MonoBehaviour, IPointerUpHandler
{
    public int slotnum;
    public Item item;
    public Image itemlcon;

    public bool isShopMode;
    public bool isSell = false;
    public GameObject checksell;

    public bool isquickslots;
    [SerializeField]
    State playerState;

    public void UpdateSlotUI()
    {
        itemlcon.sprite = item.itemImage;
        itemlcon.gameObject.SetActive(true);

    }
    public void RemoveSlot()
    {
        item = null;
        itemlcon.gameObject.SetActive(false);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (item != null)
        {            

            if (!isShopMode)
            {
                  bool isUse = item.Use();
                  if (isUse)
                  {
                     Inventory.instance.RemoveItem(slotnum);
                  }       
            }

            else
            {
                //상점
                isSell = true;
                checksell.SetActive(isSell);
            }
        }            
    }
    public void SellItem()
    {
        if(isSell)
        {
            PlayerState.instance.money += item.ItemSell;
            Inventory.instance.RemoveItem(slotnum);
            isSell = false;
            checksell.SetActive(isSell);
        }
    }

    private void OnDisable()
    {
        isSell = false;
        checksell.SetActive(isSell);
    }
}
