using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PoolType
{
    Monster,
    Tower,
    Effect
}

public enum MonsterType
{
    Ghost,
    Devil,
    SandMan
}

public class PoolManager : MonoBehaviour
{
    public static PoolManager Instance;
    public List<GameObject> poolPrefabs;

    public MSerializableDictionary<string, Queue<GameObject>> poolQueues =
        new MSerializableDictionary<string, Queue<GameObject>>();

    private void Awake() => Instance = this;

    public void InitPool(GameObject poolPrefab)
    {
        if(!poolQueues.ContainsKey(poolPrefab.name))
            poolQueues.Add(poolPrefab.name, new Queue<GameObject>());

        {
            GameObject go = Instantiate(poolPrefab, transform);
            poolQueues[poolPrefab.name].Enqueue(go);
            go.SetActive(false);
        }
    }

    public GameObject Spawn(String key)
    {
        if(!poolQueues.ContainsKey(key) || poolQueues[key].Count <=0)
            InitPool(poolPrefabs.Find(x=>x.name == key));

        GameObject go = poolQueues[key].Dequeue();
        go.SetActive(true);
        return go;
    }

    public void Despawn(GameObject obj)
    {
        poolQueues[obj.name.Split('(')[0]].Enqueue(obj);
        obj.SetActive(false);
    }
}