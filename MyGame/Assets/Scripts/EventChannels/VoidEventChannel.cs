using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Data/EventChannels/VoidEventChannel",fileName ="VoidEventChannel_")]
public class VoidEventChannel : ScriptableObject
{
    event System.Action Delegate;
    public void Broadcast()
    {
        Delegate?.Invoke();
    }
    //参数为委托处理函数
    public void AddListener(System.Action action)
    {
        Delegate += action;
    }
    //委托结束
    public void RemoveListener(System.Action action)
    {
        Delegate -= action;
    }
}
