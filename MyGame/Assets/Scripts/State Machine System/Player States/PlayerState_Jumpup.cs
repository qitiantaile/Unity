using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/StateMachine/PlayerState/Jumpup", fileName = "PlayerState_Jumpup")]
public class PlayerState_Jumpup : PlayerState
{
    [SerializeField] float JumpForce = 7f;
    [SerializeField] float MoveSpeed = 5f;
    public override void Enter()
    {
        base.Enter();
        input.HasJumpInputBuffer = false;
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
