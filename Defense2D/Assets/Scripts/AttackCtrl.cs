using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCtrl : MonoBehaviour
{
    public float speed = 1f;
    public int damage;

    private Vector3 monsterPos;

    public void SetMonsterPos(Vector3 pos)
    {
        monsterPos = pos;
    }

    private void Update()
    {
        ChaseEnemy();
    }

    public void ChaseEnemy()
    {

        var vec = monsterPos - transform.position;
        var dir = vec.normalized;
        transform.position += dir * speed * Time.deltaTime;
        Debug.Log(dir * speed * Time.deltaTime);

    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("충돌함");
        if (other.CompareTag("Monster"))
        {
            Monster monster = other.gameObject.GetComponent<Monster>();

            
            //            monster.Damaged(damage);
            PoolManager.Instance.Despawn(this.gameObject);
        }
    }



}
