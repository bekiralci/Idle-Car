using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{

    #region EventManager
    private void OnEnable()
    {
        EventManager.ObjectPool += GetThis;
    }
    private void OnDisable()
    {
        EventManager.ObjectPool -= GetThis;
    }
    private ObjectPool GetThis()
    {
        return this;
    }
    #endregion

    [Serializable]
    public struct Pool
    {
        public string name;
        public List<GameObject> pooledObjects;
        public GameObject objectPrefab;
        public int poolSize;
    }

    public Pool[] pools = null;
    private void Start()
    {
        CreateTheObjects();
    }

    private void CreateTheObjects()
    {
        for (int j = 0; j < pools.Length; j++)
        {
            pools[j].pooledObjects = new List<GameObject>();

            for (int i = 0; i < pools[j].poolSize; i++)
            {
                GameObject obj = Instantiate(pools[j].objectPrefab);
                pools[j].pooledObjects.Add(obj);
                obj.gameObject.SetActive(false);
            }
        }
    }

    public void ToPool(string name, GameObject go)
    {

        for (int i = 0; i < pools.Length; i++)
        {
            if (pools[i].name == name)
            {
                pools[i].pooledObjects.Add(go);
            }
        }

    }

    public GameObject GetTheObject(string name)
    {

        List<GameObject> handleList = new();

        for (int i = 0; i < pools.Length; i++)
        {
            if (pools[i].name == name)
            {
                handleList = pools[i].pooledObjects;
                print("bulundu");
            }
        }

        if (handleList.Count == 0)
        {
            return null;
        }

        GameObject obj = handleList[0];

        handleList.Remove(obj);

        obj.SetActive(true);

        return obj;

    }

}
