using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/StateMachine/PlayerState/FightIdle", fileName = "PlayerState_FightIdle")]
public class PlayerState_FightIdle : PlayerState
{
    public override void LogicUpdate()
    {
        if (input.Move)
        {
            stateMachine.SwitchState(typeof(PlayerState_Run));
        }
        if (input.Fight)
        {
            stateMachine.SwitchState(typeof(PlayerState_Fight));
        }
        if (input.ReadyFor)
        {
            stateMachine.SwitchState(typeof(PlayerState_Idle));
        }
        if (input.Jump)
        {
            stateMachine.SwitchState(typeof(PlayerState_Jumpup));
        }
        if (!player.isGrounded)
        {
            stateMachine.SwitchState(typeof(PlayerState_Fall));
        }
    }
}
