using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ScriptableObject可程序化对象
public class PlayerState : ScriptableObject, Istate
{
    protected float currentSpeed;
    //控制动画
    protected Animator animator;
    //控制状态切换
    protected PlayerStateMachine stateMachine;

    protected LafeiMovement player;
    protected PlayerInput input;
    public void Initialize(Animator animator,PlayerInput input,LafeiMovement player ,PlayerStateMachine playerStateMachine)
    {
        this.animator = animator;
        this.input = input;
        this.player = player;
        this.stateMachine = playerStateMachine;
    }
    //加入virtual修饰符，可以让子类重写
    public virtual void Enter()
    {
        
    }

    public virtual void Exit()
    {
        
    }

    public virtual void LogicUpdate()
    {
        
    }

    public virtual void PhysicUpdate()
    {
        
    }
}
