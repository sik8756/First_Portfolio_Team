using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ItemEft/Consumable/Mana")]
public class ItemManaEft1 : ItemEffect
{
    public int ManaPoint = 0;
    public override bool ExecuteRole()
    {
        Debug.Log("마나포션 사용함");
        if (PlayerState.instance.maxmana > PlayerState.instance.mana)
        {
            PlayerState.instance.mana += ManaPoint;

            if (PlayerState.instance.maxmana < PlayerState.instance.mana)
            {
                int sum = PlayerState.instance.mana - PlayerState.instance.maxmana;

                PlayerState.instance.mana -= sum;
            }
        }
        return true;
    }

}
