using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    Inventory inven;

    public GameObject InventoryPanel;
    bool activeInventory = false;

    public Slot[] slots;
    public Transform slotHolder;

    public GameObject shop;
    public Button closeShop;

    public ShopData shopData;
    public ShopSlot[] shopSlots;
    public Transform shopHolder;

    public bool isShopActive;

    private void Start()
    {
        inven = Inventory.instance;
        slots = slotHolder.GetComponentsInChildren<Slot>();
        shopSlots = shopHolder.GetComponentsInChildren<ShopSlot>();
        for(int i = 0; i < shopSlots.Length; i++)
        {
            shopSlots[i].Init(this);
            shopSlots[i].slotnum = i;
        }
        inven.onSlotCountChange += SlotChange;
        inven.onChangeItem += RedrawSlotUI;
        RedrawSlotUI();
        InventoryPanel.SetActive(activeInventory);
        closeShop.onClick.AddListener(DeActiveShop);
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
            RayShop();   
    }
    private void SlotChange(int val)
    {
        for(int i = 0; i < slots.Length; i++)
        {
            slots[i].slotnum = i;

            if (i < inven.SlotCnt)
                slots[i].GetComponent<Button>().interactable = true;
            else
                slots[i].GetComponent<Button>().interactable = false;
        }
    }

    public void InventoryButten()
    {
        if(!isShopActive)
        {
            activeInventory = !activeInventory;
            InventoryPanel.SetActive(activeInventory);
        }

    }

     void RedrawSlotUI()
    {
        for (int i = 0; i< slots.Length; i++)
        {
            slots[i].RemoveSlot();
        }
        for (int i = 0; i<inven.items.Count; i++)
        {
            slots[i].item = inven.items[i];
            slots[i].UpdateSlotUI();

        }
    }


    public void RayShop()
    {
        Touch touch = Input.GetTouch(0);

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(touch.position);
        mousePos.z = -10;


            RaycastHit2D hit2D = Physics2D.Raycast(mousePos, transform.forward, 30);
            if (hit2D.collider != null)
            {
                if (hit2D.collider.CompareTag("Shop"))
                {
                    if (!isShopActive)
                    {
                        ActiveShop(true);
                        shopData = hit2D.collider.GetComponent<ShopData>();
                        for (int i = 0; i < shopData.stocks.Count; i++)
                        {
                            shopSlots[i].item = shopData.stocks[i];
                            shopSlots[i].UpdateSlotUI();

                        }
                    }
                }
            }
        
    }

    public void ActiveShop(bool isOpen)
    {
        if(!activeInventory)
        {
            isShopActive = isOpen;
            shop.SetActive(isOpen);
            InventoryPanel.SetActive(isOpen);
            for (int i = 0; i <slots.Length; i++)
            {
                slots[i].isShopMode = isOpen;
            }
        }
    }

    public void DeActiveShop()
    {
        ActiveShop(false);
        shopData = null;
        for (int i = 0; i <shopSlots.Length; i++)
        {
            shopSlots[i].RemoveSlot();
            shopSlots[i].Exit();
        }
    }

    public void SellBtn()
    {
        for (int i = slots.Length; i > 0; i--)
        {
            slots[i - 1].SellItem();
        }
    }
}
