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
            Debug.Log(transform.position.y);
            if (force > 0)
                force *= -1;
            once = true;
        }
        else if (transform.position.y < 0 && !once)
        {
            Debug.Log(transform.position.y);
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
            
            Spawner.Instance.Despawn(this.gameObject);
        }
    }
}
