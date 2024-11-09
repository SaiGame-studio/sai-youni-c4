using UnityEngine;

public class TextExpCount : TextAbstact
{
    protected virtual void FixedUpdate()
    {
        this.LoadCount();
    }

    protected virtual void LoadCount()
    {
        ItemInventory item = InventoriesManager.Instance.Currency().FindItem(ItemCode.PlayerExp);
        string count;
        if (item == null) count = "0";
        else count = item.itemCount.ToString();
        this.textPro.text = count;

    }
}
