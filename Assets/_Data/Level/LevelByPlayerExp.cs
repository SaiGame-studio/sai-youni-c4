using UnityEngine;

public class LevelByPlayerExp : LevelByItem
{
    protected override ItemCode GetItemCodeName()
    {
        return ItemCode.PlayerExp;
    }
}
