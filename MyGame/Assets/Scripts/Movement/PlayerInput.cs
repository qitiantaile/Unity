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

    //��ֹ�̼�����ǰ���°��������뻺����
    public bool HasJumpInputBuffer { get; set; }
    //������Ծ��������
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
        //������Ծ�����canceled�¼�,���ɿ���Ծ��
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
    //�������ں�����ʵʱ��GUI����ʾ��Ϣ
    private void OnGUI()
    {
        //��ʾ��Ϣ
        //����һ����Ϣ��ʾ����
        //���������ı���Ϣ
        //��������GUI��ʽ
        Rect rect = new Rect(200, 200, 200, 200);
        string message = "Has Jump Input Buffer:" + HasJumpInputBuffer;
        GUIStyle style = new GUIStyle();
        style.fontSize = 20;
        style.fontStyle = FontStyle.Bold;
        GUI.Label(rect,message,style);
    }
    */
    //��װЭ��
    public void SetJumpInputBufferTimer()
    {
        //��ֹͬһЭ�̷�������
        StopCoroutine(nameof(JumpInputBufferCoroutine));
        StartCoroutine(nameof(JumpInputBufferCoroutine));
    }
    //��Ծ���뻺��Э��
    IEnumerator JumpInputBufferCoroutine()
    {
        HasJumpInputBuffer = true;
        //����ȴ�waitJumpInputBufferTimeʱ��
        yield return waitJumpInputBufferTime;

        HasJumpInputBuffer = false;
    }
}
