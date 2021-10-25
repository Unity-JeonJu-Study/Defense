using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StageMonsterData", menuName = "Monster/Data", order = 0)]
public class MonsterScript : ScriptableObject
{
    public List<MonsterData> data;
}

[Serializable]
public class MonsterData
{
    public float maxHp;
    public int rewardGold;
}
