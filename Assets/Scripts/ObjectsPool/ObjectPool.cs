using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EndlessRun.ObstacleSpawn
{
    public class ObjectPool : MonoBehaviour
    {
        [System.Serializable]
        public struct Pool
        {
            // yeni bir s�ra yani Queue olu�turuyoruz.
            public Queue<GameObject> pooledObjects;
            public GameObject objectPrefab;
            public int poolSize;
        }

        // struct yap�s�ndan array olu�turuyoruz.
        [SerializeField] private Pool[] pools = null;

        private void Awake()
        {
            for (int j = 0; j < pools.Length; j++)
            {
                pools[j].pooledObjects = new Queue<GameObject>();

                for (int i = 0; i < pools[j].poolSize; i++)
                {
                    GameObject obj = Instantiate(pools[j].objectPrefab);
                    obj.SetActive(false);

                    // objeyi s�raya al�yoruz.
                    pools[j].pooledObjects.Enqueue(obj);
                } 
            }
        }

        public GameObject GetPooledObject(int objectType)
        {
            if (objectType >= pools.Length)
            {
                return null;
            }

            // objeyi s�radan ��kar�yoruz.
            GameObject obj = pools[objectType].pooledObjects.Dequeue();
            obj.SetActive(true);

            // objeyi s�raya geri ekledik.
            pools[objectType].pooledObjects.Enqueue(obj);

            return obj;
        }
    }
}
