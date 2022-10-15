using GameInput;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    InputActions playerInputActions;

    [SerializeField] float jumpInputBufferTime = 0.5f;

    WaitForSeconds waitJumpInputBufferTime;
    Vector2 axes => playerInputActions.Game.Move.ReadValue<Vector2>();

    //防止吞键，提前按下按键将进入缓冲区
    public bool HasJumpInputBuffer { get; set; }
    //按下跳跃键返回真
    public bool Jump => playerInputActions.Game.Jump.WasPressedThisFrame();

    public bool Fight => playerInputActions.Game.Fight.WasPressedThisFrame();
    public bool StopJump => playerInputActions.Game.Jump.WasReleasedThisFrame();

    public bool ReadyFor => playerInputActions.Game.Ready.WasPressedThisFrame();

    public bool Move => AxisX != 0f;
    public float AxisX => axes.x;

    private void Awake()
    {
        playerInputActions = new InputActions();
        waitJumpInputBufferTime = new WaitForSeconds(jumpInputBufferTime); 
    }

    private void Update()
    {
        
    }
    private void OnEnable()
    {
        //订阅跳跃输入的canceled事件,即松开跳跃键
        playerInputActions.Game.Jump.canceled += delegate
        {
            HasJumpInputBuffer = false;
        };
    }
    public void EnableGameplayInputs()
    {
        playerInputActions.Game.Enable();
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void DisableGameplayInputs()
    {
        playerInputActions.Game.Disable();
    }

    /*
    //生命周期函数，实时在GUI上显示信息
    private void OnGUI()
    {
        //显示信息
        //参数一：信息显示区域
        //参数二：文本信息
        //参数三：GUI样式
        Rect rect = new Rect(200, 200, 200, 200);
        string message = "Has Jump Input Buffer:" + HasJumpInputBuffer;
        GUIStyle style = new GUIStyle();
        style.fontSize = 20;
        style.fontStyle = FontStyle.Bold;
        GUI.Label(rect,message,style);
    }
    */
    //包装协程
    public void SetJumpInputBufferTimer()
    {
        //防止同一协程反复开启
        StopCoroutine(nameof(JumpInputBufferCoroutine));
        StartCoroutine(nameof(JumpInputBufferCoroutine));
    }
    //跳跃输入缓冲协程
    IEnumerator JumpInputBufferCoroutine()
    {
        HasJumpInputBuffer = true;
        //挂起等待waitJumpInputBufferTime时间
        yield return waitJumpInputBufferTime;

        HasJumpInputBuffer = false;
    }
}
