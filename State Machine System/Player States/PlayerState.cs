using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ScriptableObject�ɳ��򻯶���
public class PlayerState : ScriptableObject, Istate
{
    protected float currentSpeed;
    //���ƶ���
    protected Animator animator;
    //����״̬�л�
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
    //����virtual���η���������������д
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
