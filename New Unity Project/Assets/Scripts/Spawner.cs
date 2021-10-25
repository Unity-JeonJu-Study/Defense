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

public enum PoolType
{
    Monster,
    Bullet
}

public class Spawner : MonoBehaviour
{
    public static Spawner Instance;
    public List<GameObject> poolPrefabs;

    public MSerializableDictionary<string, Queue<GameObject>> poolQueues =
        new MSerializableDictionary<string, Queue<GameObject>>();

    private void Awake() => Instance = this;

    private void Start()
    {
        foreach (var poolPrefab in poolPrefabs)
        {
            
            InitPool(poolPrefab, poolPrefab.name);
        }
    }

    public void InitPool(GameObject poolPrefab, string name)
    {
        int initCount = 0;
        if (!poolQueues.ContainsKey(poolPrefab.name))
            poolQueues.Add(poolPrefab.name, new Queue<GameObject>());

        switch (name)
        {
            case "Ghost2":
                initCount = 6;
                break;
            case "Bullet":
                initCount = 5;
                break;
            default:
                initCount = 3;
                break;

        }
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
            InitPool(poolPrefabs.Find(x => x.name == key), "a");
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