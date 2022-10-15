using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//创建泛型单例
public class Singleton<T> : MonoBehaviour where T : Component
{
    public static T instance { get; private set; }
    //继承该类可重写次函数
    protected virtual void Awake()
    {
        instance = this as T;
    }
}
