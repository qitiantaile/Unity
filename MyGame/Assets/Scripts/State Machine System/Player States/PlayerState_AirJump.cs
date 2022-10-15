using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/StateMachine/PlayerState/AirJump",fileName ="PlayerState_AirJump")]
public class PlayerState_AirJump : PlayerState
{
    [SerializeField] float JumpForce = 7f;
    [SerializeField] float MoveSpeed = 5f;
    public override void Enter()
    {
        base.Enter();
        //·ÀÖ¹Á¬Ðø¿ÕÖÐÌøÔ¾
        player.CanAirJumnp = false;
        player.SetVelocityY(JumpForce);
    }
    public override void LogicUpdate()
    {
        if (input.StopJump || player.isFalling)
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
        player.Move(player.WallDetector.IsGrounded ? 0f : MoveSpeed);
    }
}
