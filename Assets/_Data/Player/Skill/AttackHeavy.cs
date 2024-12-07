using UnityEngine;

public class AttackHeavy : AttackAbstract
{
    protected string effectName = "Projectile2";
    protected float timer = 0;
    protected float delay = 0.1f;
    protected SoundName shootSfxName = SoundName.LaserOneShoot;

    protected override void Attacking()
    {
        if (!InputManager.Instance.IsAttackHeavy()) return;

        this.timer += Time.deltaTime;
        if (this.timer < this.delay) return;
        this.timer = 0;

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
