using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InventorySystem
{
    public class GameItem : MonoBehaviour
    {
        [SerializeField]
        ItemStack m_stack;

        [SerializeField]
        SpriteRenderer m_spriteRenderer;

        private Collider2D m_collider;
        private Rigidbody2D m_rb;
        public ItemStack Stack => m_stack;

        [Header("Throw Setting")]
        [SerializeField]
        float m_colliderEnableAfter = 1f;

        [SerializeField]
        float m_throwGrarvity = 2f;

        [SerializeField]
        float m_ThrowminXForce = 3f;

        [SerializeField]
        float m_ThrowmaxXForce = 5f;

        [SerializeField]
        float m_throwYForce = 5f;
        private void Awake()
        {
            m_collider = GetComponent<Collider2D>();
            m_rb = GetComponent<Rigidbody2D>();
            m_collider.enabled = false;
        }

        private void Start()
        {
            SetupGameObject();
            StartCoroutine(EnableCollider(m_colliderEnableAfter));
        }
        private void OnValidate()
        {
            SetupGameObject();
            AdjustNumOfItems();
            UpodateGameObjectName();
        }
        void SetupGameObject()
        {
            if(m_stack.Packet == null)
            {
                return;
            }
            SetGameSprite();
        }
        void SetGameSprite()
        {
            m_spriteRenderer.sprite = m_stack.Packet.inGameSprite;
        }
        void UpodateGameObjectName()
        {
            var name = m_stack.Packet.name;
            var number = m_stack.isStacked ? m_stack.NumOfItems.ToString() : "ns";
            gameObject.name = $"{name} ({number})";
        }
        void AdjustNumOfItems()
        {
            m_stack.NumOfItems = m_stack.NumOfItems;
        }
        public ItemStack Pick()
        {
            Destroy(gameObject);
            return m_stack;
        }

        private IEnumerator EnableCollider(float afterTime)
        {
            yield return new WaitForSeconds(afterTime);
            m_collider.enabled = true;
        }

        public void Throw(float xDir)
        {
            m_rb.gravityScale = m_throwGrarvity;
            var throwForceX = Random.Range(m_ThrowminXForce, m_ThrowmaxXForce);
            m_rb.velocity = new Vector2(Mathf.Sign(xDir) * throwForceX,m_throwYForce);
            StartCoroutine(DisableGrarvity(m_throwYForce));
        }

        private IEnumerator DisableGrarvity(float atYVelocity)
        {
            yield return new WaitUntil(() => m_rb.velocity.y < -atYVelocity);
            m_rb.velocity = Vector2.zero;
            m_rb.gravityScale = 0;
        }

        public void SetStack(ItemStack itemStack)
        {
            m_stack = itemStack;
        }
    }
}