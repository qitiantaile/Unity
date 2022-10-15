using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarGem : MonoBehaviour
{
    [SerializeField] float resetTime = 3f;
    CircleCollider2D collider;
    //渲染器，星星被吃掉后过一段时间会生成
    SpriteRenderer spriteRenderer;

    WaitForSeconds waitResetTime;
    private void Awake()
    {
        collider = GetComponent<CircleCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        waitResetTime = new WaitForSeconds(resetTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<LafeiMovement>(out LafeiMovement player))
        {
            player.CanAirJumnp = true;
            //让星星消失，同时关闭碰撞体
            collider.enabled = false;
            spriteRenderer.enabled = false;

            //延时调用函数，生成星星
            //参数一：调用函数的函数名,字符串参数
            //参数二：延时调用时间
            //函数性能并不是很好，应采用协程替代
            //Invoke(nameof(Reset), resetTime);
            StartCoroutine(ResetCoroutine());
        }

    }
    private void Reset()
    {
        collider.enabled=true;
        spriteRenderer.enabled = true;
    }

    IEnumerator ResetCoroutine()
    {
        yield return waitResetTime;
        Reset();
    }
}
