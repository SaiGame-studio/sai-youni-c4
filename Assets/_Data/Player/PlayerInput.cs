using Invector.vCharacterController;
using UnityEngine;

public class PlayerInput : vThirdPersonInput
{
    [SerializeField] protected PlayerThirdPersonCtrl playerController;

    protected override void InitilizeController()
    {
        this.playerController = GetComponent<PlayerThirdPersonCtrl>();
        this.cc = this.playerController;

        if (cc != null) this.playerController.PlayerInit();
    }
}
