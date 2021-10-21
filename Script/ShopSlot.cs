using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class ShopSlot : MonoBehaviour, IPointerUpHandler
{
    public int slotnum;

    public Item item;
    public Image itemlcon;
    public Image Panel;
    public Image PanelIcon;
    public Text text;
    public Text moneytext;

    public Button[] buy;
    public Button[] exit;
    InventoryUI inventoryui;

    public void Init(InventoryUI Iui)
    {
        inventoryui = Iui;
    }
    private void Start()
    {
        buy[slotnum].onClick.AddListener(Buy);
        exit[slotnum].onClick.AddListener(Exit);
    }
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
        if (item != null && itemlcon.sprite != null)
        {
            Panel.gameObject.SetActive(true);
            PanelIcon.sprite = item.itemImage;
            text.text = item.iteminstruction;
            moneytext.text = item.ItemCost.ToString() + "원";

            for (int i = 0; i<6; i++)
            {
                buy[i].gameObject.SetActive(false);
                exit[i].gameObject.SetActive(false);
                if(i == slotnum)
                {
                    buy[slotnum].gameObject.SetActive(true);
                    exit[slotnum].gameObject.SetActive(true);
                }
            }
        }
    }

    public void Buy()
    {
          if (PlayerState.instance.money >= item.ItemCost && Inventory.instance.items.Count < Inventory.instance.SlotCnt)
          {
              PlayerState.instance.money -= item.ItemCost;
              Inventory.instance.AddItem(item);
              UpdateSlotUI();
              Panel.gameObject.SetActive(false);
          }
    }

    public void Exit()
    {
        Panel.gameObject.SetActive(false);       
    }
}
