using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarGem : MonoBehaviour
{
    [SerializeField] float resetTime = 3f;
    CircleCollider2D collider;
    //��Ⱦ�������Ǳ��Ե����һ��ʱ�������
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
            //��������ʧ��ͬʱ�ر���ײ��
            collider.enabled = false;
            spriteRenderer.enabled = false;

            //��ʱ���ú�������������
            //����һ�����ú����ĺ�����,�ַ�������
            //����������ʱ����ʱ��
            //�������ܲ����Ǻܺã�Ӧ����Э�����
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
