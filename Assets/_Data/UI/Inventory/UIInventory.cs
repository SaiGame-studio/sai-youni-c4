using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInventory : SaiSingleton<UIInventory>
{
    [SerializeField] protected bool isShow = true;
    protected bool IsShow => isShow;

    [SerializeField] protected Transform showHide;

    [SerializeField] protected BtnItemInventory defaultItemInventoryUI;
    [SerializeField] protected List<BtnItemInventory> btnItems = new();

    protected virtual void FixedUpdate()
    {
        this.ItemsUpdating();
    }

    protected virtual void LateUpdate()
    {
        //this.HotkeyToogleInventory();
    }

    protected override void Start()
    {
        base.Start();
        this.HideDefaultItemInventory();
        this.Hide();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBtnItemInventory();
        this.LoadShowHide();
    }

    protected virtual void LoadShowHide()
    {
        if (this.showHide != null) return;
        this.showHide = transform.Find("ShowHide");
        Debug.Log(transform.name + ": LoadShowHide", gameObject);
    }

    protected virtual void LoadBtnItemInventory()
    {
        if (this.defaultItemInventoryUI != null) return;
        this.defaultItemInventoryUI = GetComponentInChildren<BtnItemInventory>();
        Debug.Log(transform.name + ": LoadBtnItemInventory", gameObject);
    }

    public virtual void Show()
    {
        this.isShow = true;
        this.showHide.gameObject.SetActive(this.isShow);
    }

    public virtual void Hide()
    {
        this.showHide.gameObject.SetActive(false);
        this.isShow = false;
    }

    public virtual void Toggle()
    {
        if (this.isShow) this.Hide();
        else this.Show();
    }

    protected virtual void HideDefaultItemInventory()
    {
        this.defaultItemInventoryUI.gameObject.SetActive(false);
    }

    protected virtual void ItemsUpdating()
    {
        if (!this.isShow) return;

        InventoryCtrl itemInvCtrl = InventoriesManager.Instance.Item();

        BtnItemInventory newBtnItem;
        foreach (ItemInventory itemInventory in itemInvCtrl.Items)
        {
            newBtnItem = this.GetExistItem(itemInventory);
            if (newBtnItem == null)
            {
                newBtnItem = Instantiate(this.defaultItemInventoryUI);
                newBtnItem.transform.SetParent(this.defaultItemInventoryUI.transform.parent);
                newBtnItem.SetItem(itemInventory);
                newBtnItem.transform.localScale = new Vector3(1, 1, 1);
                newBtnItem.gameObject.SetActive(true);
                newBtnItem.name = itemInventory.GetItemName() + "-" + itemInventory.ItemID;
                this.btnItems.Add(newBtnItem);
            }
        }
    }

    protected virtual BtnItemInventory GetExistItem(ItemInventory itemInventory)
    {
        foreach (BtnItemInventory itemInvUI in this.btnItems)
        {
            if (itemInvUI.ItemInventory.ItemID == itemInventory.ItemID) return itemInvUI;
        }
        return null;
    }

    //protected virtual void HotkeyToogleInventory()
    //{
    //    if (InputHotkeys.Instance.IsToogleInventoryUI) this.Toggle();
    //}
}

