using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/StateMachine/PlayerState/Land",fileName ="PlayerState_Land")]
public class PlayerState_Land : PlayerState
{
    [SerializeField] float stiffTime = 0.2f;
    public override void Enter()
    {
        base.Enter();
        player.CanAirJumnp = true;
        player.SetVelocity(Vector3.zero);
    }
    public override void LogicUpdate()
    {
        if (StateDuration < stiffTime)
        {
            return;
        }
        if (player.victory)
        {
            stateMachine.SwitchState(typeof(PlayerState_Victory));
        }
        //»º³åÇøÓÐÊäÈë
        if (input.HasJumpInputBuffer || input.Jump)
        {
            stateMachine.SwitchState(typeof(PlayerState_Jumpup));
        }
        if (input.Move)
        {
            stateMachine.SwitchState(typeof(PlayerState_Run));
        }
        if (IsAnimationFinished)
        {
            stateMachine.SwitchState(typeof (PlayerState_Idle));
        }
    }

}
