using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(menuName ="Data/StateMachine/PlayerState/Idle",fileName="PlayerState_Idle")]
public class PlayerState_Idle : PlayerState
{
    [SerializeField] float deceleration = 5f;
    public override void Enter()
    {
        animator.Play("Idle");
        //��ȡ��ǰ�ٶ�
        currentSpeed = player.MoveSpeed;
    }
    public override void LogicUpdate()
    {
        if(input.Move)
        {
            stateMachine.SwitchState(typeof(PlayerState_Run));
        }
        currentSpeed = Mathf.MoveTowards(currentSpeed, 0f, deceleration * Time.deltaTime);
    }
    public override void PhysicUpdate()
    {
        player.SetVelocityX(currentSpeed * player.transform.localScale.x);
    }
}
