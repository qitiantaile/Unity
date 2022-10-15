using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    [SerializeField]
    Test input;

    [SerializeField]
    float moveSpeed = 2f;

    [SerializeField]
    float jumpForce = 7.5f;

    [SerializeField]
    float accelerationTime = 3f;

    [SerializeField]
    float decelerationTime = 3f;

    [SerializeField]
    float paddingX = 0.2f;

    [SerializeField]
    float paddingY = 0.2f;

    bool m_grounded = false;
    new Rigidbody2D rigidbody;
    Animator animator;
    Coroutine moveCoroutine;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    private void OnEnable()
    {
        input.onMove += Move;
        input.onStopMove += StopMove;
        input.onFight += Fight;
        input.onJump += Jump;
        input.onStopMove += StopJump;
    }

    private void OnDisable()
    {
        input.onMove -= Move;
        input.onStopMove -= StopMove;
        input.onFight -= Fight;
        input.onJump -= Jump;
        input.onStopMove-= StopJump;
    }


    private void Move(Vector2 moveInput)
    {
        
        if(moveCoroutine != null)
        {
            StopCoroutine(moveCoroutine);
        }
        if(moveInput.x >= 0)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        moveCoroutine = StartCoroutine(MoveCoroutine(accelerationTime,moveInput.normalized * moveSpeed,2));
        StartCoroutine(MovePositionLimitCoroutine());
    }
    void StopMove()
    {
        if (moveCoroutine != null)
        {
            StopCoroutine(moveCoroutine);
        }

        StopCoroutine(MovePositionLimitCoroutine());
        moveCoroutine = StartCoroutine(MoveCoroutine(decelerationTime,Vector2.zero,0));
    }

    //协程，用来解决与时间相关的问题
    //视口，限制移动区域
    IEnumerator MovePositionLimitCoroutine()
    {
        while (true)
        {
            transform.position = ViewPort.instance.PlayerMoveablePosition(transform.position, paddingX, paddingY);
            yield return null;
        }
    }
    IEnumerator MoveCoroutine(float time ,Vector2 moveVelocity,int state)
    {
        float t = 0f;
        while(t < time)
        {
            t += Time.fixedDeltaTime;
            rigidbody.velocity = Vector2.Lerp(rigidbody.velocity, moveVelocity, t / time);
            animator.SetFloat("AirSpeed", rigidbody.velocity.y);
            Debug.Log(rigidbody.velocity.y);
            animator.SetInteger("Transition", state);
            //挂起直到下一帧
            yield return null;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        rigidbody.gravityScale = 1f;
        input.EnableGamePlayInput();
    }

    void Fight()
    {
        animator.SetTrigger("Fight");
    }
    
    IEnumerator JumpCoroutine()
    {
        while (true)
        {
            //检查人物是否位于地面
            if (!m_grounded )
            {
                m_grounded = true;
                animator.SetBool("Grounded", m_grounded);
            }
            //检查人物是否正在下落
            if (m_grounded )
            {
                m_grounded = false;
                animator.SetBool("Grounded", m_grounded);
            }

            if (m_grounded)
            {
                animator.SetTrigger("Jump");
                m_grounded = false;
                animator.SetBool("Grounded", m_grounded);
                rigidbody.velocity = new Vector2(rigidbody.velocity.x, jumpForce);
            }

            yield return null;
        }
    }
    void Jump()
    {
        StartCoroutine(JumpCoroutine());
    }

    void StopJump()
    {
        StopCoroutine(JumpCoroutine());
    }
}
