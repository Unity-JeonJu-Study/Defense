using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControlller : MonoBehaviour
{
    public int damage = 10;

    public float force = 200f;
    public bool once;
    private void OnEnable()
    {
        
        StartCoroutine(DestroyBullet());

        once = false;
    }

    private void Update()
    {
        if (transform.position.y > 0 && !once)
        {
            force = force > 0 ? -force : force;
            once = true;
        }
        else if (transform.position.y < 0 && !once)
        {
            force = Mathf.Abs(force);
            once = true;
        }
        transform.position += new Vector3(0, force * Time.deltaTime, 0);
    }

    private IEnumerator DestroyBullet()
    {
        yield return new WaitForSeconds(1f);
        var spawner = Spawner.Instance;
        spawner.Despawn(this.gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Monster"))
        {
            MonsterCtrl monster = collision.GetComponent<MonsterCtrl>();
            monster.hp -= damage;
            if (monster.hp <= 0)
                collision.gameObject.SetActive(false);
            Spawner.Instance.Despawn(this.gameObject);
        }
    }
}
