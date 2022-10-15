using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/StateMachine/PlayerState/Victory", fileName = "PlayerState_Victory")]
public class PlayerState_Victory : PlayerState
{
    public override void Enter()
    {
        base.Enter();
        input.DisableGameplayInputs();

    }


}
