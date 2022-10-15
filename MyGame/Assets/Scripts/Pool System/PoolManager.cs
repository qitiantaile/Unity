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

    //OnDestroy�����ڱ༭��ֹͣ��Ϸ�����Զ�����
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
            //�ֵ�ļ�Ψһ
            if (dictionary.ContainsKey(pool.Prefab))
            {
                continue;
            }
            dictionary.Add(pool.Prefab,pool);
            Transform PoolParent = new GameObject("Pool:" + pool.Prefab.name).transform;
            //�ع��������صĶ����Ϊ��transform�ĸ�����
            PoolParent.parent = transform;
            pool.Initialize(PoolParent);
        }
    }

    //��̬���������е����ö�������Ǿ�̬��
    //�ͷŶ������Ԫ��
    public static GameObject Release(GameObject prefab)
    {
        if (!dictionary.ContainsKey(prefab))
        {
            Debug.Log("Pool Manager could NOT find prefab:" + prefab.name);
            return null;
        }
        return dictionary[prefab].PrepareObject();
    }
    //����
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
