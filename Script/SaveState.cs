using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "SaveState", menuName = "Scriptable Object/Player_SaveState", order = int.MaxValue)]
public class SaveState : ScriptableObject
{
    //초기스탯상태
    //최대체력
    public int maxhp;
    //최대마나
    public int maxmana;
    //공격력
    public float damage;
    //이동속도
    public float speed;
    //대쉬
    public float dash;
    //점프
    public float jump;
    //돈
    public int money;
}
