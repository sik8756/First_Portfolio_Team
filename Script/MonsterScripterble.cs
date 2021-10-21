using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "MonsterData", menuName = "Scriptable Object/MonsterData",order =int.MaxValue)]
public class MonsterScripterble : ScriptableObject
{
    [SerializeField]
    private string MonsterName;
    public string monstername { get { return MonsterName; } }
    [SerializeField]
    private int Hp;
    public int hp { get { return Hp; } }
    [SerializeField]
    private int MonsterDamage;
    public int monsterdamage { get { return MonsterDamage; } }
    [SerializeField]
    private float MonsterDamageRange;
    public float monsterdamagerange { get { return MonsterDamageRange; } }
    [SerializeField]
    private float MonsterDamageDelay;
    public float monsterdamagedelay { get { return MonsterDamageDelay; } }
    [SerializeField]
    private float MonsterSpeed;  
    public float monsterspeed { get { return MonsterSpeed; } }
    [SerializeField]
    private GameObject Groot_Attack;
    public GameObject groot_attack { get { return Groot_Attack; } }


}
