using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LafeiMovement : MonoBehaviour
{
    PlayerInput input;
    new Rigidbody2D rigidbody;
    PlayerGroundDetector groundDetector;
    [SerializeField] VoidEventChannel levelClearedEventChannel;

    [SerializeField] PlayerGroundDetector wallDetector;
    public bool victory { get; private set; }
    public PlayerGroundDetector WallDetector => wallDetector;
    public float MoveSpeed => Mathf.Abs(rigidbody.velocity.x);
    public bool isGrounded => groundDetector.IsGrounded;
    public bool CanAirJumnp { get; set; } = true;
    public bool isFalling => rigidbody.velocity.y < 0f && !isGrounded ;
    private void Awake()
    {
        groundDetector = GetComponentInChildren<PlayerGroundDetector>();
        rigidbody = GetComponent<Rigidbody2D>();
        input= GetComponent<PlayerInput>();
    }
    private void OnEnable()
    {
        levelClearedEventChannel.AddListener(OnLevelCleared);
    }
    private void OnDisable()
    {
        levelClearedEventChannel.RemoveListener(OnLevelCleared);
    }
    public void OnDefeated()
    {
        input.DisableGameplayInputs();
        rigidbody.velocity = Vector3.zero;
        rigidbody.gravityScale = 0;
        rigidbody.simulated = false;
        GetComponent<PlayerStateMachine>().SwitchState(typeof(PlayerState_Defeated));
    }
    void OnLevelCleared()
    {
        victory = true;
    }
    private void Start()
    {
        input.EnableGameplayInputs();
    }
    //控制移动和移动方向
    public void Move(float Speed)
    {
        if (input.Move)
        {
            transform.localScale = new Vector3(-input.AxisX, 1f, 1f);
        }
        SetVelocityX(Speed * input.AxisX);
    }
    public void SetVelocity(Vector3 velocity)
    {
        rigidbody.velocity = velocity;
    }
    public void SetVelocityX(float velocityX)
    {
        rigidbody.velocity = new Vector3(velocityX,rigidbody.velocity.y);
    }
    public void SetVelocityY(float velocityY)
    {
        rigidbody.velocity = new Vector3(rigidbody.velocity.x,velocityY);
    }
    public void SetUseGravity(float value)
    {
        rigidbody.gravityScale = value;
    }
}
