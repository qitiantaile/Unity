using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/StateMachine/PlayerState/CoyoteTime", fileName = "PlayerState_CoyoteTime")]
//����ʱ��ʵ�����ܲ�״̬������
public class PlayerState_CoyoteTime : PlayerState
{
    [SerializeField] float runSpeed = 5f;
    [SerializeField] float coyoteTime = 0.1f; 
    public override void Enter()
    {
        base.Enter();
        //��ɫʧȥ����
        player.SetUseGravity(0);
    }

    public override void Exit()
    {
        player.SetUseGravity(1);
    }
    public override void LogicUpdate()
    {
        //���һ,����ʱ���������ֹͣ�ƶ����������״̬
        //�������������Ծ����������״̬
        if (input.Jump)
        {
            stateMachine.SwitchState(typeof(PlayerState_Jumpup));
        }
        if (StateDuration > coyoteTime || !input.Move)
        {
            stateMachine.SwitchState(typeof(PlayerState_Fall));
        }
        if (input.Fight)
        {
            stateMachine.SwitchState(typeof(PlayerState_Fight));
        }
    }
    public override void PhysicUpdate()
    {
        player.Move(runSpeed);
    }
}
