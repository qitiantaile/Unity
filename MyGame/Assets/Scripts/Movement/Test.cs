using GameInput;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Player Input")]
public class Test : ScriptableObject,InputActions.IGameActions
{
    public event UnityAction<Vector2> onMove = delegate { };
    public event UnityAction onStopMove = delegate { };
    public event UnityAction onJump = delegate { };
    public event UnityAction onFight = delegate { };

    InputActions inputActions;


    private void OnEnable()
    {
        inputActions = new InputActions();

        inputActions.Game.SetCallbacks(this);
    }

    private void OnDisable()
    {
        DisableAllInput();
    }
    public void DisableAllInput()
    {
        inputActions.Game.Disable();
    }
    public void EnableGamePlayInput()
    {
        inputActions.Game.Enable();
        //启用动作表隐藏鼠标
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    
    public void OnMove(InputAction.CallbackContext ctx)
    {
        if(ctx.phase == InputActionPhase.Performed)
        {
            if(onMove != null)
                onMove.Invoke(ctx.ReadValue<Vector2>());
        }
        if(ctx.phase == InputActionPhase.Canceled)
        {
            if(onStopMove != null)
            {
                onStopMove.Invoke();
            }
        }
    }

    public void OnNextItem(InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }

    public void OnPreviousItem(InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }

    public void OnThrowItem(InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }


    public void OnJump(InputAction.CallbackContext ctx)
    {
        if (ctx.phase == InputActionPhase.Performed)
        {
            if (onJump != null)
                onJump.Invoke();
        }

    }

    public void OnFight(InputAction.CallbackContext ctx)
    {
        if (ctx.phase == InputActionPhase.Performed)
        {
            if (onFight != null)
                onFight.Invoke();
        }
        
    }

    public void OnReady(InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }
}
