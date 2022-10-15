using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//库存槽
namespace InventorySystem
{
    [Serializable]
    public class InventorySlot
    {
        //建立事件发生器，事件名字StateChanged，事件中的方法类InventorySlotStateArgs
        public event EventHandler<InventorySlotStateArgs> StateChanged;


        [SerializeField]  
        private ItemStack m_state;

        bool m_active;

        public bool HasItem => m_state ? .Packet != null;

        public Packet Item => m_state?.Packet;
        public ItemStack State
        {
            get => m_state;
            set
            {
                m_state = value;
                NotifyAboutStateChange();
            }
        }

        public bool Active
        {
            get => m_active;
            set
            {
                m_active = value;
                NotifyAboutStateChange();
            }
        }

        public int NumberofItems
        {
            get => m_state.NumOfItems;
            set
            {
                m_state.NumOfItems = value;
                NotifyAboutStateChange();
            }
        }
        public void Clear()
        {
            State = null;
        }
        void NotifyAboutStateChange()
        {
            //建立反射实例，Invoke第一个参数应用对象，第二个参数是调用方法
            StateChanged?.Invoke(this,new InventorySlotStateArgs(m_state,m_active));
        }
    }
}