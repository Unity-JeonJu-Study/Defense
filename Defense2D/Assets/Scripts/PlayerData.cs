using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// 플레이어, 즉 게임을 진행하고 있는 사람의 정보(골드, 제한시간(옵션))
public class PlayerData : MonoBehaviour
{
    // 플레이어는 한명 -> singleton
    public static PlayerData Instance;

    // 일단 소유 골드만
    public int mGold;
    
    private void Awake()
    {
        Instance = this;
        mGold = 100;
    }
}
