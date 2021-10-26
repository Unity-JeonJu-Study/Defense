using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 게임 매니저에는 현재 스테이지에 대해서
// 생성할 몬스터 정보를 가진다.
// 스테이지 정보
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public MonsterDataInfo MonstersInfo;

    [HideInInspector] public int currentStage;

    private void Awake()
    {
        Instance = this;
        currentStage = 0;
    }

    private void Start()
    {
        StartCoroutine(SpawnByStage());
    }

    // 스테이지 정보에 따른 몬스터 스폰ㄴ
    IEnumerator SpawnByStage()
    {
        if (currentStage == 0)
        {
            int i = 0;
            while (i < 10)
            {
                yield return new WaitForSeconds(1.5f);
                PoolManager.Instance.Spawn(((MonsterType) currentStage).ToString());
                i++;
            }
        }
    }
}
