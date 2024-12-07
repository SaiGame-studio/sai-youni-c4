using Invector.vCharacterController;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class PlayerCtrl : SaiSingleton<PlayerCtrl>
{
    [SerializeField] protected PlayerThirdPersonCtrl thirdPersonCtrl;
    public PlayerThirdPersonCtrl ThirdPersonController => thirdPersonCtrl;

    [SerializeField] protected vThirdPersonCamera thirdPersonCamera;
    public vThirdPersonCamera ThirdPersonCamera => thirdPersonCamera;

    [SerializeField] protected CrosshairPointer crosshairPointer;
    public CrosshairPointer CrosshairPointer => crosshairPointer;

    [SerializeField] protected Rig aimingRig;
    public Rig AimingRig => aimingRig;

    [SerializeField] protected WeaponsManager weapons;
    public WeaponsManager Weapons => weapons;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadThirdPersonCtrl();
        this.LoadThirdPersonCamera();
        this.LoadCrosshairPointer();
        this.LoadAimingRig();
        this.LoadWeapons();
    }

    protected virtual void LoadWeapons()
    {
        if (this.weapons != null) return;
        this.weapons = GetComponentInChildren<WeaponsManager>();
        Debug.Log(transform.name + ": LoadWeapons", gameObject);
    }

    protected virtual void LoadAimingRig()
    {
        if (this.aimingRig != null) return;
        this.aimingRig = transform.Find("Model").Find("AimingRig").GetComponent<Rig>();
        Debug.Log(transform.name + ": LoadAimingRig", gameObject);
    }

    protected virtual void LoadCrosshairPointer()
    {
        if (this.crosshairPointer != null) return;
        this.crosshairPointer = GetComponentInChildren<CrosshairPointer>();
        Debug.Log(transform.name + ": LoadCrosshairPointer", gameObject);
    }

    protected virtual void LoadThirdPersonCtrl()
    {
        if (this.thirdPersonCtrl != null) return;
        this.thirdPersonCtrl = GetComponent<PlayerThirdPersonCtrl>();
        Debug.Log(transform.name + ": LoadThirPersonCtrl", gameObject);
    }


    protected virtual void LoadThirdPersonCamera()
    {
        if (this.thirdPersonCamera != null) return;
        this.thirdPersonCamera = GameObject.FindAnyObjectByType<vThirdPersonCamera>();
        this.thirdPersonCamera.rightOffset = 0.6f;
        this.thirdPersonCamera.defaultDistance = 1.2f;
        this.thirdPersonCamera.height = 1.5f;
        this.thirdPersonCamera.yMinLimit = -40f;
        this.thirdPersonCamera.yMaxLimit = 40f;
        Debug.Log(transform.name + ": LoadThirdPersonCamera", gameObject);
    }
}
