using UnityEngine;

public class InventoryItemCtrl : InventoryCtrl
{
    public override InventoryType GetName()
    {
        return InventoryType.Item;
    }
}
