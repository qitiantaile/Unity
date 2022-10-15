using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InventorySystem         //加入命名空间，只有导入调用才能使用该背包类
{
    [CreateAssetMenu(menuName ="Inventory/Item Definition",fileName ="New item definition")]
    public class Packet : ScriptableObject
    {
        [SerializeField]
        string m_name;

        [SerializeField]
        bool m_isStackable;

        [SerializeField]
        Sprite m_inGameSprite;

        [SerializeField]
        Sprite m_uiSprite;

        public string name => m_name;
        public bool isStackable => m_isStackable;
        public Sprite uiSprite => m_uiSprite;   
        public Sprite inGameSprite => m_inGameSprite;
    }
}
