using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InventorySystem
{

    public class ItemCollisionHandler : MonoBehaviour
    {
        private Inventory m_inventory;
        private void Awake()
        {
            m_inventory = GetComponentInParent<Inventory>();
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(!collision.TryGetComponent<GameItem>(out var gameItem) || !m_inventory.CanAcceptItem(gameItem.Stack))
            {
                return;
            }
            m_inventory.AddItem(gameItem.Pick());
        }
    }
}
