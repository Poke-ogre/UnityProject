using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pooler : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public string name;
        public int quantity;
        public GameObject parent;
        public GameObject prefab;
        public Queue<GameObject> objectList;
    }

    public List<Pool> pools;

    #region Singleton
    public static Pooler Singleton;

    private void Awake()
    {
        Singleton = this;
    }
    #endregion

    private void Start()
    {
        foreach(Pool p in pools)
        {
            p.objectList = new Queue<GameObject>();

            for (int i = 0; i < p.quantity; i++)
            {
                GameObject obj = Instantiate(p.prefab);
                obj.transform.SetParent(p.parent.transform);
                obj.SetActive(false);
                p.objectList.Enqueue(obj);
            }
        }
    }

    public GameObject InstantiateFromPool(string name)
    {
        Pool pool = pools.Find(p => p.name == name);
        GameObject obj = pool.objectList.Dequeue();
        obj.SetActive(true);
        return obj;
    }

    public void DestroyToPool(string name, GameObject obj)
    {
        Pool pool = pools.Find(p => p.name == name);
        pool.objectList.Enqueue(obj);
    }

    public void DestroyToPoolWithTimer(string name, GameObject obj, float time)
    {
        Debug.Log("Destroying!");
        Pool pool = pools.Find(p => p.name == name);
        pool.objectList.Enqueue(obj);
        //yield return null;
    }
}
