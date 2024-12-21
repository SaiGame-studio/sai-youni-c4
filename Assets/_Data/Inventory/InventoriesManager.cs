using System.Collections.Generic;
using UnityEngine;

public class InventoriesManager : SaiSingleton<InventoriesManager>
{
    [SerializeField] protected List<InventoryCtrl> inventories;
    [SerializeField] protected List<ItemProfileSO> itemProfiles;

    protected override void Start()
    {
        base.Start();
        //Invoke(nameof(this.LoadGameData), 3f);
        this.LoadGameData();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadInventories();
        this.LoadItemProfiles();
    }

    public virtual void SaveGameData()
    {
        ItemInventory itemGold = this.Currency().FindItem(ItemCode.Gold);
        if (itemGold != null) GameManager.Instance.Save.SaveInit("gold", itemGold.itemCount);

        ItemInventory itemExp = this.Currency().FindItem(ItemCode.PlayerExp);
        if (itemExp != null) GameManager.Instance.Save.SaveInit("exp", itemExp.itemCount);
    }

    public virtual void LoadGameData()
    {
        int goldCount = GameManager.Instance.Save.LoadInit("gold");
        int expCount = GameManager.Instance.Save.LoadInit("exp");

        this.AddItem(ItemCode.Gold, goldCount);
        this.AddItem(ItemCode.PlayerExp, expCount);

        InvokeRepeating(nameof(this.SaveGameData), 5f, 5f);
    }

    protected virtual void LoadInventories()
    {
        if (this.inventories.Count > 0) return;
        foreach (Transform child in transform)
        {
            InventoryCtrl inventoryCtrl = child.GetComponent<InventoryCtrl>();
            if (inventoryCtrl == null) continue;
            this.inventories.Add(inventoryCtrl);
        }
        Debug.Log(transform.name + ": LoadInventories", gameObject);
    }

    protected virtual void LoadItemProfiles()
    {
        if (this.itemProfiles.Count > 0) return;
        ItemProfileSO[] itemProfileSOs = Resources.LoadAll<ItemProfileSO>("/");
        this.itemProfiles = new List<ItemProfileSO>(itemProfileSOs);
        Debug.Log(transform.name + ": LoadItemProfiles", gameObject);
    }

    public virtual InventoryCtrl GetByCodeName(InventoryType inventoryType)
    {
        foreach (InventoryCtrl inventory in this.inventories)
        {
            if (inventory.GetName() == inventoryType) return inventory;
        }

        return null;
    }

    public virtual ItemProfileSO GetProfileByCode(ItemCode itemCodeName)
    {
        foreach (ItemProfileSO itemProfile in this.itemProfiles)
        {
            if (itemProfile.itemCode == itemCodeName) return itemProfile;
        }

        return null;
    }

    public virtual InventoryCtrl Currency()
    {
        return this.GetByCodeName(InventoryType.Currency);
    }

    public virtual InventoryCtrl Item()
    {
        return this.GetByCodeName(InventoryType.Item);
    }

    public virtual void AddItem(ItemInventory itemInventory)
    {
        InventoryType invCodeName = itemInventory.ItemProfile.inventoryType;
        InventoryCtrl inventoryCtrl = this.GetByCodeName(invCodeName);
        inventoryCtrl.AddItem(itemInventory);
    }

    public virtual void AddItem(ItemCode itemCode, int itemCount)
    {
        ItemProfileSO itemProfile = this.GetProfileByCode(itemCode);
        ItemInventory item = new(itemProfile, itemCount);
        this.AddItem(item);
    }

    public virtual void RemoveItem(ItemCode itemCode, int itemCount)
    {
        ItemProfileSO itemProfile = this.GetProfileByCode(itemCode);
        ItemInventory item = new(itemProfile, itemCount);
        this.RemoveItem(item);
    }

    public virtual void RemoveItem(ItemInventory itemInventory)
    {
        InventoryType inventoryType = itemInventory.ItemProfile.inventoryType;
        InventoryCtrl inventoryCtrl = this.GetByCodeName(inventoryType);
        inventoryCtrl.RemoveItem(itemInventory);
    }

}
