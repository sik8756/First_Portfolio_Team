using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{   
    public MonsterScripterble monsterData;

    public string monstername;
    public int hp;
    public int damage;
    public float damagedelay;
    public float damagerange;
    public float speed;

    public static Monster monster;

    public bool playercheck;
    bool attack;

    float sum_x;
    float sum_y;
    float time;

    //부모객체
    GameObject parent;

    Rigidbody2D rigid;

    SpriteRenderer SR;

    Animator Ani;

    [SerializeField]
    Rigidbody2D parentRB;
    //행동지표를 결정할 변수
    public int nextMove;

    GameObject player;

    GameObject Groot_attack;

    void Awake()
    {
        monster = this;
        rigid = GetComponent<Rigidbody2D>();
        SR = GetComponent<SpriteRenderer>();
        Ani = GetComponent<Animator>();
        
        

        parent = transform.parent.gameObject;

        parentRB = parent.GetComponent<Rigidbody2D>();

        player = GameObject.FindGameObjectWithTag("Player");

        Think(); //행동지표(nextMove)를 바꿔줄 함수 아래에 void

        Invoke("Think", 5);     //invoke 주어진 시간이 지난 뒤, 지정된 함수를 실행하는 함수/ 5초뒤에 ""함수 실행
    }

        private void Start()
        {
           monstername = monsterData.monstername;

           switch (monstername)
           {
            case "bat":
                hp = Random.Range(monsterData.hp,(monsterData.hp + 8));
                damage = Random.Range(monsterData.monsterdamage,(monsterData.monsterdamage + 6));
                damagedelay = monsterData.monsterdamagedelay;
                damagerange = monsterData.monsterdamagerange;
                speed = monsterData.monsterspeed;
                break;
            case "goblin":
                hp = Random.Range(monsterData.hp,(monsterData.hp + 11));
                damage = Random.Range(monsterData.monsterdamage,(monsterData.monsterdamage + 3));
                damagedelay = monsterData.monsterdamagedelay;
                damagerange = monsterData.monsterdamagerange;
                speed = monsterData.monsterspeed;
                break;
            case "Groot":
                hp = Random.Range(monsterData.hp,(monsterData.hp + 13));
                damage = Random.Range(monsterData.monsterdamage,(monsterData.monsterdamage+5));
                damagedelay = monsterData.monsterdamagedelay;
                damagerange = monsterData.monsterdamagerange;
                speed = monsterData.monsterspeed;
                Groot_attack = monsterData.groot_attack;
                break;
            case "skeleton":
                hp = Random.Range(monsterData.hp,(monsterData.hp+9));
                damage = monsterData.monsterdamage;
                damagedelay = monsterData.monsterdamagedelay;
                damagerange = monsterData.monsterdamagerange;
                speed = monsterData.monsterspeed;
                break;
           }

        }

    private void Update()
    {
        sum_x = Mathf.Abs(player.transform.position.x - parent.transform.position.x);
        sum_y = Mathf.Abs(player.transform.position.y - parent.transform.position.y);
        if (sum_x <= 5 && sum_y <= 1.5f)
        {
            playercheck = true;
        }
        else
        {
            playercheck = false;
        }

        if (!playercheck)
        {
            //move
            gameObject.transform.parent.transform.Translate(new Vector2(nextMove * Time.deltaTime, rigid.velocity.y)); // -1 왼쪽이동, rigid~ 현재 가지고있는 y축의 속도 0은 안됨

            //platform check
            Vector2 frontVec = new Vector2(rigid.position.x + nextMove * 0.3f, rigid.position.y); // nextmove*0.3f 는 레이캐스트 거리조절
            Debug.DrawRay(frontVec, Vector3.down, new Color(0, 1, 0)); //에디터상 레이저
            RaycastHit2D rayHit = Physics2D.Raycast(frontVec, Vector3.down, 1.8f, LayerMask.GetMask("platform"));

            if (rayHit.collider == null)
            {
                //rigid.velocity = new Vector2(nextMove * -1, rigid.velocity.y);
                nextMove = nextMove * -1; //방향을 반대로 바꿔줌
                                          //rigid.velocity = new Vector2(nextMove, rigid.velocity.y);
                                          //nextMove *= -1; //도 같음
                CancelInvoke(); // 인보크를 캔슬시킴
                Invoke("Think", 5);

            }

            //오른쪽 방향전환
            if (nextMove == 1)
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                Ani.SetBool("Walk", true);
            }
            //왼쪽 방향전환
            else if (nextMove == -1)
            {
                transform.eulerAngles = new Vector3(0, 180, 0);
                Ani.SetBool("Walk", true);
            }
            //가만히 있을때
            else if (nextMove == 0)
            {
                Ani.SetBool("Walk", false);
            }

        }
        else
        {
            switch (monstername)
            {
                case "bat":
                    {
                        CancelInvoke(); // 인보크를 캔슬시킴
                        if (player.transform.position.x < transform.position.x) // 만약 플레이어가 왼쪽에 있으면
                        {
                            transform.eulerAngles = new Vector3(0, 180, 0); // 왼쪽을 본다.
                            MonsterMove(-speed);//왼쪽이동
                        }
                        else // 그렇지 않으면(플레이어가 오른쪽에 있으면)
                        {
                            transform.eulerAngles = new Vector3(0, 0, 0); // 오른쪽을 본다.
                            MonsterMove(speed);//오른쪽이동
                        }
                    }
                    break;
                case "goblin":
                    {
                        CancelInvoke(); // 인보크를 캔슬시킴
                        if (player.transform.position.x < transform.position.x) // 만약 플레이어가 왼쪽에 있으면
                        {
                            transform.eulerAngles = new Vector3(0, 180, 0); // 왼쪽을 본다.
                            MonsterMove(-speed);//왼쪽이동
                        }
                        else // 그렇지 않으면(플레이어가 오른쪽에 있으면)
                        {
                            transform.eulerAngles = new Vector3(0, 0, 0); // 오른쪽을 본다.
                            MonsterMove(speed);//오른쪽이동
                        }
                    }
                    break;
                case "Groot":
                    {
                        if(!attack)
                        {
                            CancelInvoke(); // 인보크를 캔슬시킴
                            if (player.transform.position.x < transform.position.x) // 만약 플레이어가 왼쪽에 있으면
                            {
                                transform.eulerAngles = new Vector3(0, 180, 0); // 왼쪽을 본다.
                                if (Mathf.Abs(player.transform.position.x - transform.position.x) <= damagerange)
                                {
                                    Ani.SetBool("Walk", false);
                                    if (!attack)
                                    {
                                        time += Time.deltaTime;
                                    }

                                    if (time >= damagedelay)
                                    {
                                        //공격애니메이션 실행
                                        attack = true;
                                        time = 0;
                                        Ani.SetTrigger("Attack");
                                        Debug.Log("공격모습실행");
                                    }
                                }
                                else
                                {
                                    if(!attack)
                                    {
                                        MonsterMove(-speed);//왼쪽이동
                                    }                                  
                                }
                            }
                            else // 그렇지 않으면(플레이어가 오른쪽에 있으면)
                            {
                                transform.eulerAngles = new Vector3(0, 00, 0); // 오른쪽을 본다.
                                if (Mathf.Abs(player.transform.position.x - transform.position.x) <= damagerange)
                                {
                                    Ani.SetBool("Walk", false);
                                    if (!attack)
                                    {
                                        time += Time.deltaTime;
                                    }

                                    if (time >= damagedelay)
                                    {
                                        //공격애니메이션 실행
                                        attack = true;
                                        time = 0;
                                        Ani.SetTrigger("Attack");
                                        Debug.Log("공격모습실행");
                                    }
                                }
                                else
                                {
                                    if (!attack)
                                    {
                                        MonsterMove(speed);//왼쪽이동
                                    }
                                }

                            }
                        }
                        else
                        {
                            time = 0;
                        }
                        
                    }
                    break;
                case "skeleton":
                    {
                        CancelInvoke(); // 인보크를 캔슬시킴
                        if (player.transform.position.x < transform.position.x) // 만약 플레이어가 왼쪽에 있으면
                        {
                            transform.eulerAngles = new Vector3(0, 180, 0); // 왼쪽을 본다.
                            MonsterMove(-speed);//왼쪽이동
                        }
                        else // 그렇지 않으면(플레이어가 오른쪽에 있으면)
                        {
                            transform.eulerAngles = new Vector3(0, 0, 0); // 오른쪽을 본다.
                            MonsterMove(speed);//오른쪽이동
                        }
                    }
                    break;
            }
        }

        if(hp <= 0)
        {
            Destroy(gameObject);
        }


    }


    //행동지표(nextMove)를 바꿔줄 함수
    //재귀 함수: 자신을 스스로 호출하는 함수
    void Think()
    {
        //Range():최소 ~ 최대 범위의 랜덤 수 생성(최대 제외 즉 2를 넣으면 1까지만 포함됨 인트가 아닐경우 1.9999??)
        nextMove = Random.Range(-1, 2); // -1일때 왼쪽으로 이동, 0일 대 idle ,오른쪽일때 1

        float nextThinkTime = Random.Range(2f, 5f); //랜덤으로 2~5초동안 움직임을 바꿈(왼쪽, 대기, 오른쪽)
        Invoke("Think", nextThinkTime); //void awake와 해당부분에 에 invoke 로 딜레이를 주지 않으면 엄청난 속도로 중첩실행됨

    }

    //적을 발견했을떄의 움직이는 함수
    void MonsterMove(float speed)
    {
        //자신의 부모객체인 parnet 의 게임오브젝트를 speed 만큼 움직인다
        parent.transform.Translate(new Vector2(speed * Time.deltaTime , 0));
        //이때 애니 Walk 의 값을 true로 변환
        Ani.SetBool("Walk", true);
        //time = 0 으로 만든이유 걸었을때 몬스터가 바로 공격하지않게 공격딜레이를 0으로 설정
        time = 0;
    }

    //애니 이벤트 실행
    public void Groot_Attack()
    {
        // groot라는 게임오브젝트에 Groot_attack 프리팹을 집어넣는다
        GameObject groot = Instantiate(Groot_attack, player.transform.position, Quaternion.identity);
        // groot는 자신의게임오브젝트에 
        groot.transform.parent = gameObject.transform;
    }
        
    public void Groot_Attack_End()
    {
        Ani.SetTrigger("AttackEnd");
        attack = false;
        
    }

    public void Hit()
    {
        parentRB.velocity = Vector2.zero;

        parentRB.AddForce(new Vector2((5 * player.GetComponent<Player>().HitDir),0), ForceMode2D.Impulse);     
    }
}
    