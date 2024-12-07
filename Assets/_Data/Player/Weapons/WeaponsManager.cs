using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponsManager : SaiBehaviour
{
    [SerializeField] protected int currentWeaponIndex = 0;
    [SerializeField] protected List<WeaponCtrl> weapons;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadWeapons();
    }

    protected virtual void LoadWeapons()
    {
        if (this.weapons.Count > 0) return;
        foreach (Transform child in transform)
        {
            WeaponCtrl weaponAbtract = child.GetComponent<WeaponCtrl>();
            if (weaponAbtract == null) continue;
            this.weapons.Add(weaponAbtract);
        }
        Debug.Log(transform.name + ": LoadWeapons", gameObject);
    }

    public virtual WeaponCtrl GetCurrentWeapon()
    {
        return this.weapons[this.currentWeaponIndex];
    }
}
