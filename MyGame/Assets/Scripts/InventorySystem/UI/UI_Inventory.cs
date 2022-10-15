using InventorySystem.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace InventorySystem.UI
{
    public class UI_Inventory : MonoBehaviour
    {
        [SerializeField]
        GameObject m_inventorySlotPrefab;

        [SerializeField]
        private Inventory m_inventory;

        [SerializeField]
        List<UI_InventorySlot> m_slots;

        public Inventory Inventory => m_inventory;

        [ContextMenu("Initialize Inventory")]

        void InitializeInventoryUI()
        {
            if (m_inventorySlotPrefab == null || m_inventory == null) return;

            m_slots = new List<UI_InventorySlot>(m_inventory.Size);
            for(var i =0; i < m_inventory.Size; i++)
            {
                var uiSlot = PrefabUtility.InstantiatePrefab(m_inventorySlotPrefab) as GameObject;
                uiSlot.transform.SetParent(transform, false);
                var uiSlotScript = uiSlot.GetComponent<UI_InventorySlot>();
                uiSlotScript.AssignSlot(i);
                m_slots.Add(uiSlotScript);

            }
        }
    }
}