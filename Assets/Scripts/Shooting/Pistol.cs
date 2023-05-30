using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Pistol : Weapon
{
    // Variables
    [SerializeField] private Projectile bulletPrefab;
    
    protected override void StartShooting(ActivateEventArgs interactor)
    {
        base.StartShooting(interactor);
        Shoot();
    }

    protected override void Shoot()
    {
        base.Shoot();
        Projectile projectileInstance = Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
        projectileInstance.Init(this);
        // Sonido y vibration
        AudioManager.instance.PlaySFX(AudioManager.instance.listaAudio[0]);
        VibrateController.instance.sendVibration(0.45f,0.02f);
        projectileInstance.Launch();
    }

    protected override void StopShooting(DeactivateEventArgs interactor)
    {
        base.StopShooting(interactor);
    }
}
