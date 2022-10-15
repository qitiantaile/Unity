using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/StateMachine/PlayerState/Float", fileName = "PlayerState_Float")]
public class PlayerState_Float : PlayerState
{
    [SerializeField] VoidEventChannel playerDefeatedEventChannel;
    [SerializeField] float floatingSpeed = 0.5f;
    //漂浮偏移值
    [SerializeField] Vector3 floatingPositionOffset;

    Vector3 floatingPosition;

    public override void Enter()
    {
        base.Enter();
        floatingPosition = player.transform.position + floatingPositionOffset;
        playerDefeatedEventChannel.Broadcast();
    }
    public override void LogicUpdate()
    {
        Transform playerTransform = player.transform;
        //每一帧更新玩家位置
        if(Vector3.Distance(playerTransform.position, floatingPosition) > floatingSpeed * Time.deltaTime)
        {
            playerTransform.position = Vector3.MoveTowards(playerTransform.position, floatingPosition, floatingSpeed * Time.deltaTime);
        }
        else
        {
            floatingPosition += (Vector3)Random.insideUnitCircle;
        }
    }
}
