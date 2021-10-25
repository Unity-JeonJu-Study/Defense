using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(SpawnMonster());
    }

    private void Update()
    {
        //StartCoroutine(SpawnMonster());
    }

    IEnumerator Yield5Sec()
    {
        yield return StartCoroutine(SpawnMonster());
    }
    IEnumerator SpawnMonster()
    {
        int i = 0;
        while (i < 11)
        {
            yield return new WaitForSeconds(1f);
            var spawner = Spawner.Instance;
            spawner.Spawn("Ghost2");
            i++;
        }
       
    }
}
