using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;

public enum MonsterType
{
    Ghost,
    SandMan2,
    AngryBear,
    LittleDevil,
    Devil
}

public class Spawner : MonoBehaviour
{
    public static Spawner Instance;
    public List<GameObject> poolPrefabsMob;

    public MSerializableDictionary<string, Queue<GameObject>> poolQueues =
        new MSerializableDictionary<string, Queue<GameObject>>();

    private void Awake() => Instance = this;

    private void Start()
    {
        foreach (var poolPrefab in poolPrefabsMob)
        {
            InitPool(poolPrefab, 5);
        }
    }

    public void InitPool(GameObject poolPrefab, int initCount)
    {
        if (!poolQueues.ContainsKey(poolPrefab.name))
            poolQueues.Add(poolPrefab.name, new Queue<GameObject>());

        for (int i = 0; i < initCount; i++)
        {
            GameObject go = Instantiate(poolPrefab, this.transform);
            poolQueues[poolPrefab.name].Enqueue(go);
            go.SetActive(false);
        }
    }

    public GameObject Spawn(string key)
    {
        if (!poolQueues.ContainsKey(key) || poolQueues[key].Count <= 0)
        {
            InitPool(poolPrefabsMob.Find(x => x.name == key), 3);
        }

        GameObject go = poolQueues[key].Dequeue();
        go.SetActive(true);
        return go;
    }
    
    public void Despawn(GameObject obj)
    {
        //poolQueues[obj.name.Split('(')[0]].Enqueue(obj);
        poolQueues[obj.name.Replace("(Clone)", string.Empty)].Enqueue(obj);
        obj.SetActive(false);
    }
}