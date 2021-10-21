using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton
    public static Inventory instance;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }
    #endregion

    public delegate void OnSlotCountChange(int val);
    public OnSlotCountChange onSlotCountChange;

    public delegate void OnChangeItem();
    public OnChangeItem onChangeItem;

    public List<Item> items = new List<Item>();

    public SpriteRenderer Player;

    public int slotCnt;

    public int SlotCnt
    {
      get => slotCnt;
        set
        {
            slotCnt = value;
            onSlotCountChange(slotCnt);
        }
    }

    void Start()
    {
        //플레이어 인벤칸 개수
        SlotCnt = 30;
    }

    //아이템 추가 함수
    public bool AddItem(Item _item)
    {
        //현재 아이템갯수가 가지고있는 플레이어 인벤칸 개수를 비교
        if(items.Count < SlotCnt)
        {
            //현재 아이템갯수가 인벤칸 개수보다 적다면
            //itme 정보를 가져와서 items리스트에 추가
            items.Add(_item);

            if (onChangeItem != null)
            {
                onChangeItem.Invoke();
            }
            //정상적으로 들어갔다면 true반환
            return true;
        }
        //들어가지 못했다면 false반환
        return false;
    }

    //아이템 제거 함수
    public void RemoveItem(int _index)
    {
        //해당칸에있는 slotnum 을 _index로 받아옴
        //imtes 리스크의 _index(slotnum)번째에 있는것을 제거
        items.RemoveAt(_index);
        onChangeItem.Invoke();
    }

    //필드에있는 필드아이템 먹기
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //만약 닿은 콜리전의 태그가 FieldItem 일경우
        if(collision.CompareTag("FieldItem"))
        {
            //fieldItems 에 닿은 아이템의 스크립트 정보를 가져옴
            FieldItem fieldItems = collision.GetComponent<FieldItem>();

            //AddItem 함수실행 (fieldItems에 있는 함수인 GetItem)을 실행
            //GetItem 함수에는 return item 으로 자신의 아이템정보를 줌
            if (AddItem(fieldItems.GetItem()))
                //AddItem 함수에 정상적으로 들어갔다면 true를 반환하여 해당필드에있는 아이템삭제
                //정상적으로 들어가지못했다면 false를 반환하여 삭제시키지 않음
                fieldItems.DestroyItem();
        }
    }

}
