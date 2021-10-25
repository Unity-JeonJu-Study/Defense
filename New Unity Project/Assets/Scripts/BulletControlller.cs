using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControlller : MonoBehaviour
{
    public int damage = 10;

    public float force = 200f;

    private void OnEnable()
    {
        Debug.Log(transform.position.y);
        if (transform.position.y > 0)
            force *= -1;
        StartCoroutine(DestroyBullet());
    }

    private void Update()
    {
        transform.position += new Vector3(0, force * Time.deltaTime, 0);
    }

    private IEnumerator DestroyBullet()
    {
        yield return new WaitForSeconds(1f);
        var spawner = Spawner.Instance;
        spawner.Despawn(this.gameObject);
        force *= -1;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Monster"))
        {
            
            Spawner.Instance.Despawn(this.gameObject);
        }
    }
}
