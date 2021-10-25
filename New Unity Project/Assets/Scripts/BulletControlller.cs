using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControlller : MonoBehaviour
{
    public int damage = 10;

    public float force = 200f;

    private void Awake()    
    {
        if (transform.position.y > 0)
            force *= -1;
    }

    private void Start()
    {
        StartCoroutine(DestroyBullet());
    }

    private void Update()
    {
        transform.position += new Vector3(0, force * Time.deltaTime, 0);
    }

    private IEnumerator DestroyBullet()
    {
        yield return new WaitForSeconds(5f);
        Destroy(this.gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Monster"))
        {
            MonsterController mc = collision.GetComponent<MonsterController>();
            mc.hp -= damage;
            Debug.Log(mc.hp);
        }
    }
}
