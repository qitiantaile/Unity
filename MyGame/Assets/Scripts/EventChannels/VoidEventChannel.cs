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
    //����Ϊί�д�������
    public void AddListener(System.Action action)
    {
        Delegate += action;
    }
    //ί�н���
    public void RemoveListener(System.Action action)
    {
        Delegate -= action;
    }
}