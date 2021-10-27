using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightCtrl : MonoBehaviour
{
    public int damage;
    public float radius;
    public int idx;

    private Animator anim;
    private AttackCtrl attackCtrl;
    private Vector3 pos;
    private Collider[] colls;
    private GameObject attack;
    private GameObject monster;
    private float distance;

    private void Awake()
    {
        damage = 10;
        radius = 10f;
        pos = GetComponent<Transform>().position;
        distance = 0;
        anim = GetComponent<Animator>();
    }

    private void Start()
    {
        StartCoroutine(Attack());
    }

    IEnumerator Attack()
    {
        while (true)
        {       
            yield return new WaitForSeconds(0.1f);
            if (distance == 0 || distance > 5f)
            {
                colls = Physics.OverlapSphere(pos,
                                              radius,
                                                   1 << 3);
                Debug.Log(colls);
                idx = Random.Range(0, colls.Length);
            }
            
            if (colls != null)
            {
                Debug.Log("aa");

                Debug.Log(idx + "\t" + colls.Length);
                monster = colls[idx].gameObject;
                distance = Vector3.Distance(monster.transform.position, this.gameObject.transform.position);
                //리스
                attack = PoolManager.Instance.Spawn("Attack");
                attack.transform.position = this.transform.position;
                attackCtrl = attack.GetComponent<AttackCtrl>();
                attackCtrl.damage = damage;
                attackCtrl.SetMonsterPos(monster.transform.position);
                anim.SetBool("attack", true);

            }
            yield return new WaitForSeconds(0.75f);
            anim.SetBool("attack", false);

        }
    }
}
