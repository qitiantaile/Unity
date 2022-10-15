using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InventorySystem
{
    [Serializable]
    public class ItemStack
    {
        [SerializeField]
        Packet m_packet;

        [SerializeField]
        int m_numOfItems;

        public bool isStacked => m_packet != null && m_packet.isStackable;
        public Packet Packet => m_packet;
        public int NumOfItems
        {
            get => m_numOfItems;
            set
            {
                value = value < 0 ? 0 : value; //ȷ��value����ֵ
                m_numOfItems = isStacked ? value : 1;         //�ɶѵ���Ϊvalue�����ɶѵ���Ϊ1
            }
        }
        public ItemStack(Packet packet,int numOfItems)
        {
            m_packet = packet;
            m_numOfItems = numOfItems;
        }
        public ItemStack()      //���Ϊ�յ����
        {

        }
    }
}