using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

//真正的库存,库存主脚本
namespace InventorySystem
{
    public class Inventory : MonoBehaviour
    {
        //库存大小，即总格数
        [SerializeField]
        int m_size = 8;

        public int Size => m_size;
        //列表，库存格数
        [SerializeField]
        List<InventorySlot> m_slots;

        public List<InventorySlot> Slots => m_slots;

        int m_activeSlotIndex;

        public int ActiveSlotIndex
        {
            get => m_activeSlotIndex;
            private set
            {
                m_slots[m_activeSlotIndex].Active = false;
                m_activeSlotIndex = value < 0 ? m_size - 1 : value % Size;
                m_slots[m_activeSlotIndex].Active = true;
            }
        }

        private void Awake()
        {
            if(m_size > 0)
            {
                m_slots[0].Active = true;
            }
        }
        private void OnValidate()
        {
            AdjustSize();
        }
        void AdjustSize()
        {
            //if (m_slots == null) m_slots = new List<InventorySlot>();
            m_slots ??= new List<InventorySlot>();
            //去除多余的格数
            if(m_slots.Count > m_size) m_slots.RemoveRange(m_size,m_slots.Count - m_size);
            //填充少于的格数
            if (m_slots.Count < m_size) m_slots.AddRange(new InventorySlot[m_size - m_slots.Count]);
        }

        //检查是否库存已满
        public bool IsFull()
        {
            return m_slots.Count(slot => slot.HasItem) >= m_size;
        }

        public bool Something(InventorySlot slot)
        {
            return slot.HasItem;
        }

        private InventorySlot FindSlot(Packet item, bool onlyStackable = false)
        {
            return m_slots.FirstOrDefault(slot => slot.Item == item &&
                                                                    item.isStackable || !onlyStackable);
        }
        public bool CanAcceptItem(ItemStack itemStack)
        {
            var slotWithStackableItem = FindSlot(itemStack.Packet,true);
            return !IsFull() || slotWithStackableItem != null ;
        }

        public bool HasItem(ItemStack itemStack,bool checkNumOfItems = false)
        {
            var itemSlot =FindSlot(itemStack.Packet);
            if(itemSlot == null) return false;
            if (checkNumOfItems)
            {
                if (itemStack.Packet.isStackable)
                {
                    return itemSlot.NumberofItems >= itemStack.NumOfItems;
                }
                return m_slots.Count(slot => slot.Item == itemStack.Packet) >= itemStack.NumOfItems;
            }
            return true;
        }
        public ItemStack AddItem(ItemStack itemStack)
        {
            var releventSlot = FindSlot(itemStack.Packet, true);
            //库存已满
            if(IsFull() && releventSlot == null)
            {
                throw new InventoryException(InventoryOperation.Add, "Inventory is Full");
            }
            if(releventSlot != null)
            {
                releventSlot.NumberofItems += itemStack.NumOfItems;
            }
            else
            {
                releventSlot = m_slots.First(slot => !slot.HasItem);
                releventSlot.State = itemStack;
            }
            return releventSlot.State;
        }

        //根据索引清除物品
        public ItemStack RemoveItem(int atIndex,bool spawn = false)
        {
            if (!m_slots[atIndex].HasItem)
                throw new InventoryException(InventoryOperation.Remove, "Slot is Empty!");
            if (spawn && TryGetComponent<GameItemSpawner>(out var itemSpawner))
            {
                itemSpawner.SpwanItem(m_slots[atIndex].State);
            }
            ClearSlot(atIndex);
            return new ItemStack();
        }

        public ItemStack RemoveItem(ItemStack itemStack)
        {
            var itemSlot = FindSlot(itemStack.Packet);
            if(itemSlot == null)
                throw new InventoryException(InventoryOperation.Remove, "No item in the Inventory!");
            if(itemSlot.Item.isStackable && itemSlot.NumberofItems < itemSlot.NumberofItems)
                throw new InventoryException(InventoryOperation.Remove, "No enough items!");
            itemSlot.NumberofItems -= itemSlot.NumberofItems;
            if (itemSlot.Item.isStackable && itemSlot.NumberofItems > 0)
            {
                return itemSlot.State;
            }
            itemSlot.Clear();
            return new ItemStack();
        }
        public void ClearSlot(int atIndex)
        {
            m_slots[atIndex].Clear();
        }
        public void ActivateSlot(int atIndex)
        {
            ActiveSlotIndex = atIndex;
        }

        public InventorySlot GetActiveSlot()
        {
            return m_slots[ActiveSlotIndex];
        }
    }
}