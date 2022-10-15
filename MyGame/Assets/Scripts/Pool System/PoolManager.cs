using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    [SerializeField] Pool[] playerProjectilesPools;
    static Dictionary<GameObject, Pool> dictionary;
    private void Start()
    {
        dictionary = new Dictionary<GameObject, Pool>();
        Initialize(playerProjectilesPools);
    }

    //OnDestroy函数在编辑器停止游戏运行自动调用
    private void OnDestroy()
    {
        CheckPoolSize(playerProjectilesPools);
    }
    void CheckPoolSize(Pool[] pools)
    {
        foreach(var pool in pools)
        {
            if(pool.RunTimeSize > pool.Size)
            {
                Debug.LogWarning((string.Format("Pool:{0} has a runtime size {1} bigger than initial size {2}!"),
                    pool.Prefab.name,
                    pool.RunTimeSize,
                    pool.Size));
            }
        }
    }
    void Initialize(Pool[] pools)
    {
        foreach(var pool in pools)
        {
            //字典的键唯一
            if (dictionary.ContainsKey(pool.Prefab))
            {
                continue;
            }
            dictionary.Add(pool.Prefab,pool);
            Transform PoolParent = new GameObject("Pool:" + pool.Prefab.name).transform;
            //池管理器挂载的对象成为该transform的父对象
            PoolParent.parent = transform;
            pool.Initialize(PoolParent);
        }
    }

    //静态函数中所有的引用对象必须是静态的
    //释放对象池中元素
    public static GameObject Release(GameObject prefab)
    {
        if (!dictionary.ContainsKey(prefab))
        {
            Debug.Log("Pool Manager could NOT find prefab:" + prefab.name);
            return null;
        }
        return dictionary[prefab].PrepareObject();
    }
    //重载
    public static GameObject Release(GameObject prefab,Vector3 position)
    {
        if (!dictionary.ContainsKey(prefab))
        {
            Debug.Log("Pool Manager could NOT find prefab:" + prefab.name);
            return null;
        }
        return dictionary[prefab].PrepareObject(position);
    }
    public static GameObject Release(GameObject prefab, Vector3 position,Quaternion rotation)
    {
        if (!dictionary.ContainsKey(prefab))
        {
            Debug.Log("Pool Manager could NOT find prefab:" + prefab.name);
            return null;
        }
        return dictionary[prefab].PrepareObject(position,rotation);
    }
    public static GameObject Release(GameObject prefab, Vector3 position, Quaternion rotation,Vector3 localScale)
    {
        if (!dictionary.ContainsKey(prefab))
        {
            Debug.Log("Pool Manager could NOT find prefab:" + prefab.name);
            return null;
        }
        return dictionary[prefab].PrepareObject(position, rotation,localScale);
    }


}
