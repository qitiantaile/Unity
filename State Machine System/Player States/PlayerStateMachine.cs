using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : IstateMachine
{
    Animator animator;


    PlayerInput input;
    LafeiMovement player;
    [SerializeField] PlayerState[] states;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        input = GetComponent<PlayerInput>();
        player = GetComponent<LafeiMovement>();
        stateTable = new Dictionary<System.Type, Istate>(states.Length);
        //Do player initialization here;  
        foreach(var state in states)
        {
            state.Initialize(animator,input,player, this);
            stateTable.Add(state.GetType(), state);
        }
    }
    //���ݲ�ͬ״̬������ͻ��״̬

    private void Start()
    {
        SwitchOn(stateTable[typeof(PlayerState_Idle)]);
    }
}
