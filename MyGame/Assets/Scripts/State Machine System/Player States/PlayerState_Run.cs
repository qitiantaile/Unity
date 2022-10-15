using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(menuName = "Data/StateMachine/PlayerState/Run", fileName = "PlayerState_Run")]
public class PlayerState_Run : PlayerState
{
    [SerializeField] float runSpeed = 5f;
    [SerializeField] float acceration = 5f;
    public override void Enter()
    {
        base.Enter();
        currentSpeed = player.MoveSpeed;
    }
    public override void LogicUpdate()
    {
        if (!input.Move)
        {
            stateMachine.SwitchState(typeof(PlayerState_Idle));
        }
        if (input.Jump)
        {
            stateMachine.SwitchState(typeof(PlayerState_Jumpup));
        }
        if (input.Fight)
        {
            stateMachine.SwitchState(typeof(PlayerState_Fight));
        }
        if (!player.isGrounded)
        {
            stateMachine.SwitchState(typeof(PlayerState_CoyoteTime));

        }

        currentSpeed =Mathf.MoveTowards(currentSpeed, runSpeed, acceration*Time.deltaTime);
    }
    public override void PhysicUpdate()
    {
        player.Move(currentSpeed);
    }
}
