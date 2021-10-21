using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monsterspawn : MonoBehaviour
{
    [SerializeField]
    private List<MonsterScripterble> monster;
    [SerializeField]
    private List<GameObject> monsterPrefabs;
    public enum MonsterType
    {
        bat,
        goblin,
        Groot,
        skeleton,
    }
    void Awake()
    {
        var monster = SpawnMonster((MonsterType)Random.Range(0, this.monster.Count));
    }
    public Monster SpawnMonster(MonsterType type)
    {
        var newmonster = Instantiate(monsterPrefabs[(int)type],gameObject.transform.position,Quaternion.identity).GetComponentInChildren<Monster>();
        newmonster.monsterData = monster[(int)type];
        newmonster.name = newmonster.monsterData.monstername;
        return newmonster;
    }
}
    