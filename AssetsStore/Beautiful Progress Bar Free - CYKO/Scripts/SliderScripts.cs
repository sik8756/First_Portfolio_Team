using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class SliderScripts : MonoBehaviour
{

    float hp;
    float maxhp;
    Slider Sd;
    [SerializeField]
    Text text;
    GameObject Player;
    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        Sd = GetComponent<Slider>();
        
    }

    private void Update()
    {
        hp = Player.GetComponent<Player>().hp;
        maxhp = Player.GetComponent<Player>().maxhp;
        Sd.value = (hp / 100);

        text.text = hp + "/" + maxhp;
    }
}
