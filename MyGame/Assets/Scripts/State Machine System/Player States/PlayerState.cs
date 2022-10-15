using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ScriptableObject�ɳ��򻯶���
public class PlayerState : ScriptableObject, Istate
{
    [SerializeField] string stateName;
    [SerializeField,Range(0f,1f)] float transitionDuration = 0.1f; 
    
    int stateHash;
    float stateStartTime;

    protected float currentSpeed;
    //���ƶ���
    protected Animator animator;
    //����״̬�л�
    protected PlayerStateMachine stateMachine;

    protected LafeiMovement player;
    protected PlayerInput input;
    //����ǰ״̬����ʱ����ڵ��ڶ�������ʱ����ǰ�����������
    protected bool IsAnimationFinished => StateDuration >= animator.GetCurrentAnimatorStateInfo(0).length;
    //��ǰ״̬�ĳ���ʱ��
    protected float StateDuration => Time.time - stateStartTime;
    void OnEnable()
    {
        //��ȡ״̬���ƵĹ�ϣֵ��ʹ�ù�ϣֵ�������Ч��
        stateHash = Animator.StringToHash(stateName);
    }
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
        //ʵ�ֶ����Ľ��뽥��
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
