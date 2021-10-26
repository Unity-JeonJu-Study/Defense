using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 몬스터의 정보
[CreateAssetMenu(fileName = "MonsterDataInfo", menuName = "Monster/Data", order = 0)]
public class MonsterDataInfo : ScriptableObject
{
    public List<MonsterData> data;
}

// 정보에 들어갈 것
[Serializable]
public class MonsterData
{
    public float maxHp;
    public int rewardGold;
}
