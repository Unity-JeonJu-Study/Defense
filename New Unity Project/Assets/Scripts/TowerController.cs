using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerController : MonoBehaviour
{
    public GameObject bullet;
    public float timeOffSet = 1f;

    private void Start()
    {
        StartCoroutine(FireBullet());
    }

    private void Update()
    {
       
    }

    private IEnumerator FireBullet()
    {
        while(true)
        {
            var spawner = Spawner.Instance;
            GameObject a = spawner.Spawn("Bullet");
            a.transform.position = this.transform.position;
            yield return new WaitForSeconds(timeOffSet);
        }
        
    }
}
