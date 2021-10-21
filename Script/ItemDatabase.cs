using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
    public static ItemDatabase instance;

    //아이템 데이터
    public List<Item> itemDB = new List<Item>();
    [SerializeField]
    List<Transform> Pos = new List<Transform>();
    public GameObject Item;
    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        for(int i = 0; i < Pos.Count; i++)
        {
            GameObject hppotion = Instantiate(Item, Pos[i].transform.position, Quaternion.identity);
            hppotion.GetComponent<FieldItem>().SetItem(itemDB[0]);
        }
        
        
    }
}
