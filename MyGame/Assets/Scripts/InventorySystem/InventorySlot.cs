using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//����
namespace InventorySystem
{
    [Serializable]
    public class InventorySlot
    {
        //�����¼����������¼�����StateChanged���¼��еķ�����InventorySlotStateArgs
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
            //��������ʵ����Invoke��һ������Ӧ�ö��󣬵ڶ��������ǵ��÷���
            StateChanged?.Invoke(this,new InventorySlotStateArgs(m_state,m_active));
        }
    }
}