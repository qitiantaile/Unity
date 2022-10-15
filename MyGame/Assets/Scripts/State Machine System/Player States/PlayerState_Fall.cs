using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//���Դ�����ִ�л��ű��ļ�
[CreateAssetMenu(menuName = "Data/StateMachine/PlayerState/Fall", fileName = "PlayerState_Fall")]
public class PlayerState_Fall : PlayerState
{
    //���ö������߿��Ƶ����ٶ�
    [SerializeField] AnimationCurve speedCurve;
    [SerializeField] float MoveSpeed = 5f;
    public override void LogicUpdate()
    {
        if (player.isGrounded)
        {
            stateMachine.SwitchState(typeof(PlayerState_Land));
        }

        if (input.Jump)
        {
            if (player.CanAirJumnp)
            {
                stateMachine.SwitchState(typeof(PlayerState_AirJump));
                return;
            }
            input.SetJumpInputBufferTimer();
        }
        if (input.Fight)
        {
            stateMachine.SwitchState(typeof(PlayerState_Fight));
        }
    }
    public override void PhysicUpdate()
    {
        //������ʱ��,������X���ֵ
        player.SetVelocityY(speedCurve.Evaluate(StateDuration));
        player.Move(player.WallDetector.IsGrounded ? 0f : MoveSpeed);
    }
}
