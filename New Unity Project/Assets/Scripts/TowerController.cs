using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerController : MonoBehaviour
{
    public GameObject bullet;

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
            Instantiate(bullet, transform.position,
                    transform.rotation);
            
            yield return new WaitForSeconds(3f);
        }
        
    }
}
