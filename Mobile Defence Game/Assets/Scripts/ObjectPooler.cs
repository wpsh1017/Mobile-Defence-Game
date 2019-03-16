using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    public GameObject pooledObejct;
    public int poolCount = 28;
    public bool more = true;

    private List<GameObject> pooledObjects;

    private void Start()
    {
        pooledObjects = new List<GameObject>();
        while (poolCount > 0)
        {
            GameObject obj = (GameObject)Instantiate(pooledObejct);
            obj.SetActive(false);
            pooledObjects.Add(obj);
            poolCount = poolCount - 1;
            GameManager.instance.bulletAddCount++;
        }
    }

    public GameObject getObject()
    {
        foreach (GameObject obj in pooledObjects)
        {
            if (!obj.activeInHierarchy)
            {
                return obj;
            }
        }
        if (more)
        {
            GameObject obj = (GameObject)Instantiate(pooledObejct);
            pooledObjects.Add(obj);
            GameManager.instance.bulletAddCount++;
            return obj;
        }
        return null;

    }

}
