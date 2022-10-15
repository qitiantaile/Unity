using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//可以创建可执行化脚本文件
[CreateAssetMenu(menuName = "Data/StateMachine/PlayerState/Fall", fileName = "PlayerState_Fall")]
public class PlayerState_Fall : PlayerState
{
    //利用动画曲线控制掉落速度
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
        //参数是时间,即曲线X轴的值
        player.SetVelocityY(speedCurve.Evaluate(StateDuration));
        player.Move(player.WallDetector.IsGrounded ? 0f : MoveSpeed);
    }
}
