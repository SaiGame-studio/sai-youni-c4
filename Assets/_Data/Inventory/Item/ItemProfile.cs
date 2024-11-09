using UnityEngine;

public class ItemProfile : MonoBehaviour
{
    public InventoryType inventoryType;
    public ItemCode itemCode;
    public string itemName;
    public bool isStackable = false;
    public int maxStack = 99;

}