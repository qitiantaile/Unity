using GameInput;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace InventorySystem
{
    public class InventoryInputHandler : MonoBehaviour
    {
        Inventory m_inventory;

        private void Awake()
        {
            m_inventory = GetComponent<Inventory>();
        }
        private void OnEnable()
        {
            InputActions.Instance.Game.ThrowItem.performed += OnThrowItem;
            InputActions.Instance.Game.NextItem.performed += OnNextItem;
            InputActions.Instance.Game.PreviousItem.performed += OnPreviousItem;
        }
        void OnDisable()
        {
            InputActions.Instance.Game.ThrowItem.performed -= OnThrowItem;
            InputActions.Instance.Game.NextItem.performed -= OnNextItem;
            InputActions.Instance.Game.PreviousItem.performed -= OnPreviousItem;
        }
        void OnThrowItem(InputAction.CallbackContext ctx)
        {
            if (m_inventory.GetActiveSlot().HasItem)
            {
                m_inventory.RemoveItem(m_inventory.ActiveSlotIndex, true);
            }
        }

        void OnNextItem(InputAction.CallbackContext ctx)
        {
            m_inventory.ActivateSlot(m_inventory.ActiveSlotIndex + 1);
        }

        void OnPreviousItem(InputAction.CallbackContext ctx)
        {
            m_inventory.ActivateSlot(m_inventory.ActiveSlotIndex - 1);
        }
    }
}