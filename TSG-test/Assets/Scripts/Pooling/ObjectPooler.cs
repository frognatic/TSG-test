using System;
using System.Collections.Generic;
using UnityEngine;

#pragma warning disable 649
public class ObjectPooler : MonoBehaviour
{
    [Serializable]
    public class Pool
    {
        public int RodId;
        public GameObject Prefab;
    }

    public static ObjectPooler Instance;
    public List<Pool> Pools;

    [SerializeField] private Transform parentToSpawn;
    private Dictionary<int, Queue<GameObject>> poolDictionary;
    
    private void Awake()
    {
        Instance = this;
        poolDictionary = new Dictionary<int, Queue<GameObject>>();

        foreach (Pool pool in Pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();
            GameObject obj = Instantiate(pool.Prefab, parentToSpawn);
            obj.SetActive(false);
            objectPool.Enqueue(obj);

            poolDictionary.Add(pool.RodId, objectPool);
        }
    }

    public GameObject SpawnFromPool(int rodId)
    {
        if (poolDictionary.ContainsKey(rodId))
        {
            GameObject objToSpawn = poolDictionary[rodId].Dequeue();
            objToSpawn.SetActive(true);

            poolDictionary[rodId].Enqueue(objToSpawn);
            return objToSpawn;
        }

        return null;
    }

    public void Despawn(GameObject obj)
    {
        obj.gameObject.SetActive(false);
    }
}
