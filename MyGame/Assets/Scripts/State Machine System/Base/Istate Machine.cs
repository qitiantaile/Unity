using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IstateMachine : MonoBehaviour
{
    Istate currentState;

    protected Dictionary<System.Type, Istate> stateTable;
    private void Update()
    {
        currentState.LogicUpdate();
    }
    private void FixedUpdate()
    {
        currentState.PhysicUpdate();
    }
    //�ڸ���������е��ô˷���,����protected���η�
    protected void SwitchOn(Istate newState)
    {
        currentState = newState;
        currentState.Enter();
    }

    public void SwitchState(Istate newState)
    {
        currentState.Exit();
        SwitchOn(newState);
    }
    //����
    public void SwitchState(System.Type newStateType)
    {
        SwitchState(stateTable[newStateType]);
    }
}
