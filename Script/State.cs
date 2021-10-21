using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "State",menuName ="Scriptable Object/Player_plusState", order = int.MaxValue)]
public class State : ScriptableObject
{
    public int plusdamage;
    public int plusmaxhp;
    public int speed;
    public int plusmaxamana;    
}
