using UnityEngine;

public abstract class LevelByItem : LevelAbstract
{
    [SerializeField] protected ItemInventory itemInventory;

    protected abstract ItemCode GetItemCodeName();

    protected override int GetCurrentExp()
    {
        if (this.GetPlayerExp() == null) return 0;
        return this.GetPlayerExp().itemCount;
    }

    protected override bool DeductExp(int exp)
    {
        return this.GetPlayerExp().Deduct(exp);
    }

    protected virtual ItemInventory GetPlayerExp()
    {
        if (this.itemInventory == null || this.itemInventory.ItemID == 0) this.itemInventory = InventoriesManager.Instance.Currency().FindItem(this.GetItemCodeName());
        return this.itemInventory;
    }
}
