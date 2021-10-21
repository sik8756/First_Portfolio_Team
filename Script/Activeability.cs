using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Activeability : MonoBehaviour
{
    public State playerState;

    public Text Damage;
    public Text hp;
    public Text speed;
    public Text money;

    void Update()       
    {
        Damage.text = PlayerState.instance.damage.ToString();
        hp.text = PlayerState.instance.maxhp.ToString();
        money.text = PlayerState.instance.money.ToString();
    }

    public void plusDamage()
    {
        if (PlayerState.instance.money >= (1000 * (playerState.plusdamage + 1)))
        {
            PlayerState.instance.money -= (1000 * (playerState.plusdamage + 1));
            playerState.plusdamage++;
            PlayerState.instance.damage += 5;
        }
    }

    public void TestState()
    {
        SceneManager.LoadScene("2Stage");
    }
}
