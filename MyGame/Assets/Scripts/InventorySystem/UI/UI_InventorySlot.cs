using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace InventorySystem.UI
{
    public class UI_InventorySlot : MonoBehaviour
    {
        [SerializeField]
        Inventory m_inventory;

        [SerializeField]
        int m_inventorySlotIndex;

        //库存物品图标
        [SerializeField]
        Image m_itemIcon;
        //活动指示器
        [SerializeField]
        Image m_activeIndicator;

        [SerializeField]
        TMP_Text m_numOfItems;
        InventorySlot m_slot;

        private void Start()
        {
            AssignSlot(m_inventorySlotIndex);
        }
        public void AssignSlot(int slotIndex)
        {
            if (m_slot != null) m_slot.StateChanged -= OnStateChanged;
            m_inventorySlotIndex = slotIndex;
            if (m_inventory == null) m_inventory = GetComponentInParent<UI_Inventory>().Inventory;
            m_slot = m_inventory.Slots[m_inventorySlotIndex];
            m_slot.StateChanged += OnStateChanged;
            UpdateViewState(m_slot.State,m_slot.Active);
        }

        void UpdateViewState(ItemStack state,bool active)
        {
            m_activeIndicator.enabled = active;
            var item = state?.Packet;
            var hasItem = item != null;
            var isStackable = hasItem && item.isStackable;
            m_itemIcon.enabled = hasItem;
            m_numOfItems.enabled = isStackable;
            if (!hasItem) return;

            m_itemIcon.sprite = item.uiSprite;
            if(isStackable) m_numOfItems.SetText(state.NumOfItems.ToString());
        }
        void OnStateChanged(object sender,InventorySlotStateArgs args)
        {
            UpdateViewState(args.NewState,args.Active);
        }
    }
}