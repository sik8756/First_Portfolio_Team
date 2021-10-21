using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    public static PlayerState instance;
    [SerializeField]
    State plusState;

    public int maxhp;
    public int hp;
    public int maxmana;
    public int mana;
    public float damage;
    public int money;
    
    private void Awake()
    {
        saveState();
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;

        for (int plus = 0; plus < plusState.plusmaxhp; plus++)
        {
            maxhp += 5;
            hp += 5;
        }


        for (int plus = 0; plus < plusState.plusmaxamana; plus++)
        {
            maxmana += 5;
            mana += 5;
        }


        for (int plus = 0; plus < plusState.plusdamage; plus++)
        {
            damage += 5;
        }

        LoadState();
    }

    public void saveState()
    {
        PlayerPrefs.SetInt("hp", hp);
        PlayerPrefs.SetInt("mana", mana);
        PlayerPrefs.SetInt("money", money);
    }

    public void LoadState()
    {
        hp = PlayerPrefs.GetInt("hp");
        mana = PlayerPrefs.GetInt("mana");
        money = PlayerPrefs.GetInt("money");
    }
}
