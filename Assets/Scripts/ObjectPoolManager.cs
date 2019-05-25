using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace __Shooter__
{
    [System.Serializable]
    public class ObjectPool
    {
        public int initialAmount;
        public GameObject objectToPool;

        public List<GameObject> pooledObjects;

        public string tag;
    }

    public class ObjectPoolManager : MonoBehaviour
    {

        public List<ObjectPool> objectPools;

        public static ObjectPoolManager instance;

        void Awake()
        {
            instance = this;
            foreach (ObjectPool pool in objectPools)
            {
                pool.pooledObjects = new List<GameObject>();
                for (int i = 0; i < pool.initialAmount; i++)
                {
                    GameObject obj = Instantiate(pool.objectToPool);
                    obj.SetActive(false);
                    pool.pooledObjects.Add(obj);
                }
            }
        }

        public GameObject GetPooledObject(string tag)
        {
            foreach (ObjectPool pool in objectPools)
            {
                if (tag == pool.tag){
                    for (int i = 0; i < pool.pooledObjects.Count; i++)
                    {
                        if (!pool.pooledObjects[i].activeSelf)
                        {
                            return pool.pooledObjects[i];
                        }
                    }

                    GameObject obj = Instantiate(pool.objectToPool);
                    obj.SetActive(false);
                    pool.pooledObjects.Add(obj);
                    return obj;
                }
            }
            return null;
            
        }

        public ObjectPool GetPool(string tag)
        {
            foreach (ObjectPool pool in objectPools)
            {
                if (tag == pool.tag){
                    return pool;
                }
            }
            return null;
            
        }
    }
}
