using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/StateMachine/PlayerState/Fight", fileName = "PlayerState_Fight")]
public class PlayerState_Fight : PlayerState
{
    public override void Enter()
    {
        base.Enter();
        currentSpeed = 0f;
    }
    public override void LogicUpdate()
    { 
        if(StateDuration > 0.5f)
        {
            //fight -> run
            if (input.Move)
            {
                stateMachine.SwitchState(typeof(PlayerState_Run));
            }
            //fight -> fight
            if (input.Fight)
            {
                stateMachine.SwitchState(typeof(PlayerState_Fight));
            }
            //fight ->FightIdle
            if (!input.Move)
            {
                stateMachine.SwitchState(typeof(PlayerState_FightIdle));
            }
            //ÔÊÐíÌøÔ¾ fight -> jumpup
            if (input.StopJump || player.isFalling)
            {
                stateMachine.SwitchState(typeof(PlayerState_Fall));
            }
            //fight -> airjump
            if (input.Jump)
            {
                if (player.CanAirJumnp)
                {
                    stateMachine.SwitchState(typeof(PlayerState_AirJump));
                    return;
                }
                input.SetJumpInputBufferTimer();
            }
            //fight -> fall
            if (input.StopJump || player.isFalling)
            {
                stateMachine.SwitchState(typeof(PlayerState_Fall));
            }
            //fight -> land
            if (player.isGrounded)
            {
                stateMachine.SwitchState(typeof(PlayerState_Land));
            }
        }

    }
    public override void PhysicUpdate()
    {
        player.SetVelocityX(currentSpeed );
    }

}
