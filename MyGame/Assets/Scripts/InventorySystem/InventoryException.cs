using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem
{
    public enum InventoryOperation
    {
        Add,
        Remove
    }
    //抛出异常
    public class InventoryException:Exception
    {
        public InventoryOperation Operation { get; }
        public InventoryException(InventoryOperation operation,String msg) : base($"{operation} error: {msg}")
        {
            Operation = operation;
        }
    }
}
