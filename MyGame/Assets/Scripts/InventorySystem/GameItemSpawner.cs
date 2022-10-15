using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace InventorySystem
{
    public class GameItemSpawner : MonoBehaviour
    {
        [SerializeField]
        GameObject m_itemBasePrefab;

        public void SpwanItem(ItemStack itemstack)
        {
            if (m_itemBasePrefab == null) return;
            var item = PrefabUtility.InstantiatePrefab(m_itemBasePrefab) as GameObject;
            item.transform.position = transform.position;
            var gameItemScript = item.GetComponent<GameItem>();
            gameItemScript.SetStack(new ItemStack(itemstack.Packet, itemstack.NumOfItems));
            gameItemScript.Throw(transform.localScale.x);
        }
    }
}