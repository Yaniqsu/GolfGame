using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] List<GameObject> pooledObjects = new();
    [SerializeField] GameObject objectToPool;
    [SerializeField] int poolSize;
    [SerializeField] bool setActiveOnCreate = false;
    public int PoolSize
    {
        get => poolSize;
    }
    void Start()
    {
        GameObject obj;
        for(int i = 0; i < poolSize; i++)
        {
            obj = Instantiate(objectToPool, transform.position, Quaternion.identity);
            obj.SetActive(setActiveOnCreate);
            pooledObjects.Add(obj);
        }
    }
    public GameObject GetPooledObject()
    {
        foreach(GameObject thisObject in pooledObjects)
        {
            if (!thisObject.activeInHierarchy)
                return thisObject;
        }
        return null;
    }
    public GameObject GetObjectAt(int index)
    {
        if (index >= pooledObjects.Count) return null;

        return pooledObjects[index];
    }
    public void ToggleAllObjects(bool activeState)
    {
        foreach (GameObject g in pooledObjects)
            g.SetActive(activeState);
    }
}
