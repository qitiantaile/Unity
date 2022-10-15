using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem
{
    //写入背包相关的状态信息
    public class InventorySlotStateArgs
    {
        //信息只读，不能更改
        public ItemStack NewState { get; }
        public bool Active { get; }

        public InventorySlotStateArgs(ItemStack newState, bool active)
        {
            NewState = newState;
            Active = active;
        }
    }
}
