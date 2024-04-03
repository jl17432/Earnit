using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Seed")]
public class Seed : ScriptableObject
{
    public Sprite wait, grow, reap;
    public int growTime = 1, reapTime = 1;
    public Item seedItem,fruitItem;//种子和果实的Item
    public int energy = 10;//消耗体力
}
