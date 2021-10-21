using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ItemEft/Consumable/Health")]
public class ItemHealingEft : ItemEffect
{
    public int healingPoint = 0;
    public override bool ExecuteRole()
    {
        GameObject Player = GameObject.FindGameObjectWithTag("Player");

        Debug.Log("힐링포션 사용함");
        if(Player.GetComponent<Player>().hp > 100)
        {
            Player.GetComponent<Player>().hp += healingPoint;

            if(100 < Player.GetComponent<Player>().hp)
            {
                int sum = Player.GetComponent<Player>().hp - 100;

                Player.GetComponent<Player>().hp -= sum;
            }
        }
        return true;
    }

}
