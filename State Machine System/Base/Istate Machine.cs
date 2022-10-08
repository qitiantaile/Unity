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
    //在该类的子类中调用此方法,加入protected修饰符
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
    //重载
    public void SwitchState(System.Type newStateType)
    {
        SwitchState(stateTable[newStateType]);
    }
}
