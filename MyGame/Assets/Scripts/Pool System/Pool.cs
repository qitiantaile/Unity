using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Pool 
{
    public GameObject Prefab => prefab;
    public int Size => size;

    //��Ϸ����ʱ�ĳߴ�
    public int RunTimeSize => queue.Count;

    [SerializeField] GameObject prefab;
    //���г���
    [SerializeField] int size = 1;

    Queue<GameObject> queue;
    Transform parent;

    //��ʼ�������������������е���
    public void Initialize(Transform parent)
    {
        queue = new Queue<GameObject>();
        this.parent = parent;
        for(var i = 0; i < size; i++)
        {
            queue.Enqueue(Copy());
        }
    }


    //���ɶ����е���Ϸ����
    GameObject Copy()
    {
        var copy = GameObject.Instantiate(prefab,parent);

        Copy().SetActive(false);

        return copy;
    }

    //�Ӷ������ȡ�����ö���
    GameObject AvailableObject()
    {
        GameObject availableObject = null;
        //���в�Ϊ���ҵ�һ��Ԫ��δ���� 
        if(queue.Count > 0 && !queue.Peek().activeSelf)
        {
            availableObject = queue.Dequeue();
        }
        else
        {
            availableObject = Copy();
        }
        //�����������󷵻ض����
        queue.Enqueue(availableObject);
        return availableObject;
    }

    //���ÿ��ö���
    public GameObject PrepareObject()
    {
        GameObject prepareObject = AvailableObject();
        prepareObject.SetActive(true);
        return prepareObject;
    }
    //����
    //����λ��
    public GameObject PrepareObject(Vector3 position)
    {
        GameObject prepareObject = AvailableObject();
        prepareObject.SetActive(true);
        prepareObject.transform.position = position;
        return prepareObject;
    }
    //��Ԫ��ת����
    public GameObject PrepareObject(Vector3 position,Quaternion rotation)
    {
        GameObject prepareObject = AvailableObject();
        prepareObject.SetActive(true);
        prepareObject.transform.position = position;
        prepareObject.transform.rotation = rotation;
        return prepareObject;
    }

    //����
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
