using UnityEngine;

[CreateAssetMenu(fileName = "ItemProfile", menuName = "ScriptableObjects/ItemProfile", order = 1)]
public class ItemProfileSO : ScriptableObject
{
    //public ItemType itemType; //Currency,Weapon,Armor,Potion, Eyes, Keys
    public InventoryType inventoryType;
    public ItemCode itemCode;
    public string itemName;
    public bool isStackable = false;
    public int maxStack = 99;
}