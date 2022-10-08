using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LafeiMovement : MonoBehaviour
{
    PlayerInput input;
    Rigidbody2D rigidbody;

    public float MoveSpeed => Mathf.Abs(rigidbody.velocity.x);

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        input= GetComponent<PlayerInput>();
    }
    private void Start()
    {
        input.EnableGameplayInputs();
    }
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
}
