using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Pool 
{
    public GameObject Prefab => prefab;
    public int Size => size;

    //游戏运行时的尺寸
    public int RunTimeSize => queue.Count;

    [SerializeField] GameObject prefab;
    //队列长度
    [SerializeField] int size = 1;

    Queue<GameObject> queue;
    Transform parent;

    //初始化操作，在其他函数中调用
    public void Initialize(Transform parent)
    {
        queue = new Queue<GameObject>();
        this.parent = parent;
        for(var i = 0; i < size; i++)
        {
            queue.Enqueue(Copy());
        }
    }


    //生成队列中的游戏对象
    GameObject Copy()
    {
        var copy = GameObject.Instantiate(prefab,parent);

        Copy().SetActive(false);

        return copy;
    }

    //从对象池中取出可用对象
    GameObject AvailableObject()
    {
        GameObject availableObject = null;
        //队列不为空且第一个元素未启用 
        if(queue.Count > 0 && !queue.Peek().activeSelf)
        {
            availableObject = queue.Dequeue();
        }
        else
        {
            availableObject = Copy();
        }
        //已完成任务对象返回对象池
        queue.Enqueue(availableObject);
        return availableObject;
    }

    //启用可用对象
    public GameObject PrepareObject()
    {
        GameObject prepareObject = AvailableObject();
        prepareObject.SetActive(true);
        return prepareObject;
    }
    //重载
    //加入位置
    public GameObject PrepareObject(Vector3 position)
    {
        GameObject prepareObject = AvailableObject();
        prepareObject.SetActive(true);
        prepareObject.transform.position = position;
        return prepareObject;
    }
    //四元旋转参数
    public GameObject PrepareObject(Vector3 position,Quaternion rotation)
    {
        GameObject prepareObject = AvailableObject();
        prepareObject.SetActive(true);
        prepareObject.transform.position = position;
        prepareObject.transform.rotation = rotation;
        return prepareObject;
    }

    //缩放
    public GameObject PrepareObject(Vector3 position, Quaternion rotation,Vector3 loaclScale)
    {
        GameObject prepareObject = AvailableObject();
        prepareObject.SetActive(true);
        prepareObject.transform.position = position;
        prepareObject.transform.rotation = rotation;
        prepareObject.transform.localScale = loaclScale;
        return prepareObject;
    }
}
