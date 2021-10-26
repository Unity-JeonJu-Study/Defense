using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Monster : MonoBehaviour
{
  // 몬스터의 정보
  // 방어력을 추가하나 hp를 늘리나 같으니 hp만 설정
  [HideInInspector] public float currentHp;
  [HideInInspector] public int rewardGold;
  
  [HideInInspector] public GameObject monsterObj;
  [HideInInspector] public MonsterData monsterData;

  private Transform currentPos;

  private void Awake()
  {
    currentPos = GetComponent<Transform>();
  }

  private void Start()
  {
    // 게임 매니저에서 몬스터 정보를 가져온다. (현재 스테이지 기준)
    var game = GameManager.Instance;
    monsterData = game.MonstersInfo.data[game.currentStage];
    // 가져온 몬스터 정보에 따라 초기화 
    currentHp = monsterData.maxHp;
    rewardGold = monsterData.rewardGold;
    //monsterObj = PoolManager.Instance.Spawn(((MonsterType) game.currentStage).ToString());
  }

  private void Update()
  {
    Move();
  }

  // 이동 관련 메소드
  private void Move()
  {
    currentPos.position += new Vector3(0.8f, 0f, 0f) * Time.deltaTime;
    
  }
  
  public void Damaged(float value)
  {
    currentHp -= value;
    if (currentHp <= 0)
    {
      Dead();
    }
  }

  public void Dead()
  {
    // 처리 완료한 몬스터는 풀링(큐)로 돌려주고 비활성화
    PoolManager.Instance.Despawn(monsterObj);
    // 플레이어 골드 +
    PlayerData.Instance.mGold += rewardGold;
  }
}
