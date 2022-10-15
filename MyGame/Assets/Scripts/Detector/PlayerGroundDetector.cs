using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundDetector : MonoBehaviour
{
    [SerializeField] float detectionRadius = 0.1f;
    //层级遮罩变量
    [SerializeField] LayerMask groundLayer;
     Collider2D collider;
     Collider2D[] colliders = new Collider2D[1];
    //声明加()是函数，不加是属性
    //使用主体表达式，简洁
    //投射虚拟球体，球体与某个刚体产生碰撞，将碰撞体存储在数组中，函数返回整型值
    //参数一：球的圆心
    //参数二：球的半径
    //参数三：碰撞体存储数组
    //参数四：指定需要检测的层级
    //参数五：可选项，指定是否需要检测触发器碰撞体
    private void Awake()
    {
        collider = GetComponentInParent<Collider2D>();
    }
    public bool IsGrounded
    {
        get
        {
            return Physics2D.OverlapCircleNonAlloc(transform.position,detectionRadius, colliders, groundLayer) != 0;
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
