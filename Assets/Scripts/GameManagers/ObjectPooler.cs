using UnityEngine;
using System.Collections.Generic;
public class ObjectPooler : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }

    public static ObjectPooler Instance;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        //DontDestroyOnLoad(gameObject);
        InitializePools();
    }
    public List<Pool> pools;
    private Dictionary<string, GameObject> prefabDictionary = new();
    public Dictionary<string, List<GameObject>> poolDictionary = new();
    
    void InitializePools()
    {
        poolDictionary = new Dictionary<string, List<GameObject>>();
        prefabDictionary = new Dictionary<string, GameObject>();

        foreach (Pool pool in pools)
        {
            List<GameObject> objectPool = new List<GameObject>();

            for (int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                objectPool.Add(obj);
            }
            prefabDictionary.Add(pool.tag, pool.prefab);
            poolDictionary.Add(pool.tag, objectPool);
        }
    }

    public GameObject SpawnFromPool(string tag, Vector2 position)
    {
        if (!poolDictionary.ContainsKey(tag))
        {
            Debug.LogWarning("Pool with tag " + tag + " doesn't excist.");
            return null;
        }
        List<GameObject> list = poolDictionary[tag];

        for (int i = 0; i < list.Count; i++)
        {
            GameObject candidate = list[i];
            if (!candidate.activeInHierarchy)
            {

                candidate.transform.position = position;
                candidate.SetActive(true);
                IPooledObject pooledObj = candidate.GetComponent<IPooledObject>();
                pooledObj?.OnObjectSpawned();
                return candidate;
            }
        }

        GameObject obj = Instantiate(prefabDictionary[tag]);
        obj.transform.position = position;
        obj.SetActive(true);
        list.Add(obj);
        IPooledObject newPooled = obj.GetComponent<IPooledObject>();
        newPooled?.OnObjectSpawned();
        return obj;
    }
}