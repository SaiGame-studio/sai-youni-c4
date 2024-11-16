using UnityEngine;

public class Projectile1DamageSender : EffectDamageSender
{
    protected override string GetHitName()
    {
        return EffectCode.Hit1.ToString();
    }
}
