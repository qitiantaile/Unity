using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundDetector : MonoBehaviour
{
    [SerializeField] float detectionRadius = 0.1f;
    //�㼶���ֱ���
    [SerializeField] LayerMask groundLayer;
     Collider2D collider;
     Collider2D[] colliders = new Collider2D[1];
    //������()�Ǻ���������������
    //ʹ��������ʽ�����
    //Ͷ���������壬������ĳ�����������ײ������ײ��洢�������У�������������ֵ
    //����һ�����Բ��
    //����������İ뾶
    //����������ײ��洢����
    //�����ģ�ָ����Ҫ���Ĳ㼶
    //�����壺��ѡ�ָ���Ƿ���Ҫ��ⴥ������ײ��
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
