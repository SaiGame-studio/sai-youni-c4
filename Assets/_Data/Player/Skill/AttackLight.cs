using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackLight : AttackAbstract
{
    [SerializeField] protected string effectName = "Projectile2";
    [SerializeField] protected SoundName shootSfxName = SoundName.LaserOneShoot;

    protected override void Attacking()
    {
        if (!InputManager.Instance.IsAttackLight()) return;
        Transform attackPoint = this.GetAttackPoint();
        EffectCtrl effect = this.spawner.Spawn(this.GetEffect(), attackPoint.position);

        EffectFlyCtrl effectFly = (EffectFlyCtrl)effect;
        effectFly.FlyToTarget.SetTarget(this.playerCtrl.CrosshairPointer.transform);

        effect.gameObject.SetActive(true);

        this.SpawnSound(effectFly.transform.position);
    }

    protected virtual EffectCtrl GetEffect()
    {
        return this.prefabs.GetByName(this.effectName);
    }

    protected virtual void SpawnSound(Vector3 position)
    {
        SFXCtrl newSfx = SoundManager.Instance.CreateSfx(this.shootSfxName, position);
        newSfx.gameObject.SetActive(true);
    }
}
