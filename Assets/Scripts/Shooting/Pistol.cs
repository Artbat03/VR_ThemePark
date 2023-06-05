using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Pistol : Weapon
{
    // Variables
    [SerializeField] private Projectile bulletPrefab;
    [SerializeField] private GameObject particleSystem;
    
    protected override void StartShooting(ActivateEventArgs interactor)
    {
        base.StartShooting(interactor);
        Shoot();
    }

    protected override void Shoot()
    {
        // Launch projectile
        base.Shoot();
        Projectile projectileInstance = Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
        projectileInstance.Init(this);
        projectileInstance.Launch();

        // Sonido y vibration
        AudioManager.instance.PlaySFX(AudioManager.instance.listaAudio[0]);
        VibrateController.instance.sendVibration(0.85f,0.02f);
        
        // VFX
        particleSystem.SetActive(true);
    }

    protected override void StopShooting(DeactivateEventArgs interactor)
    {
        base.StopShooting(interactor);
        particleSystem.SetActive(false);
    }
}
