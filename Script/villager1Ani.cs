using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class villager1Ani : MonoBehaviour
{
    SpriteRenderer SR;
    Animator Ani;
    [SerializeField]
    Transform Start;
    [SerializeField]
    Transform End;
    float time;
    int Thinking;
    [SerializeField]
    float speed;
    bool check;
    bool check2;
    void Awake()
    {
        SR = GetComponent<SpriteRenderer>();
        Ani = GetComponent<Animator>();
        time = Random.Range(-2, 3);
    }

    
    void Update()
    {
        time += Time.deltaTime;

        if(time >= 7)
        {
            Thinking = Random.Range(1, 3);
            time = Random.Range(-2, 3);
            check = true;
            check2 = true;
        }
        //왼쪽
        if(Thinking == 1)
        {

            if (gameObject.transform.position.x <= Start.transform.position.x)
            {
                Thinking = 2;
                time = -1;            
            }
            if (time >= 4 && check)
            {
                Ani.SetTrigger("WalkEnd");
                Thinking = 3;
                check = false;
            }
            if(check2)
            {
                check2 = false;
                Ani.SetTrigger("Walk");
            }
            
            transform.Translate(new Vector2(-speed * Time.deltaTime , 0));
            SR.flipX = true;
        }
        //오른쪽
        else if (Thinking == 2)
        {
            if (gameObject.transform.position.x >= End.transform.position.x)
            {
                Thinking = 1;
                time = -1;
            }
            if (time >= 4 && check)
            {
                Ani.SetTrigger("WalkEnd");
                Thinking = 3;
                check = false;
            }
            if(check2)
            {
                check2 = false;
                Ani.SetTrigger("Walk");
            }
            transform.Translate(new Vector2(speed * Time.deltaTime, 0));
            SR.flipX = false;
        }

    }
}
