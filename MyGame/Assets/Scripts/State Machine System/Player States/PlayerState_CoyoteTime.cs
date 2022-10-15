using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/StateMachine/PlayerState/CoyoteTime", fileName = "PlayerState_CoyoteTime")]
//土狼时间实际是跑步状态的延续
public class PlayerState_CoyoteTime : PlayerState
{
    [SerializeField] float runSpeed = 5f;
    [SerializeField] float coyoteTime = 0.1f; 
    public override void Enter()
    {
        base.Enter();
        //角色失去重力
        player.SetUseGravity(0);
    }

    public override void Exit()
    {
        player.SetUseGravity(1);
    }
    public override void LogicUpdate()
    {
        //情况一,土狼时间结束或者停止移动，进入掉落状态
        //情况二：按下跳跃键进入起跳状态
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
