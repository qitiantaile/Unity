using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ScriptableObject可程序化对象
public class PlayerState : ScriptableObject, Istate
{
    [SerializeField] string stateName;
    [SerializeField,Range(0f,1f)] float transitionDuration = 0.1f; 
    
    int stateHash;
    float stateStartTime;

    protected float currentSpeed;
    //控制动画
    protected Animator animator;
    //控制状态切换
    protected PlayerStateMachine stateMachine;

    protected LafeiMovement player;
    protected PlayerInput input;
    //当当前状态持续时间大于等于动画长度时，当前动画播放完毕
    protected bool IsAnimationFinished => StateDuration >= animator.GetCurrentAnimatorStateInfo(0).length;
    //当前状态的持续时间
    protected float StateDuration => Time.time - stateStartTime;
    void OnEnable()
    {
        //获取状态名称的哈希值，使用哈希值可以提高效率
        stateHash = Animator.StringToHash(stateName);
    }
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
        //实现动画的渐入渐出
        animator.CrossFade(stateHash, transitionDuration);
        stateStartTime = Time.time;
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
