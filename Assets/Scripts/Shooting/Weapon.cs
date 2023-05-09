using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(XRGrabInteractable))]

public class Weapon : MonoBehaviour
{
    // Variables
    [SerializeField] protected float shootingForce;
    [SerializeField] protected Transform bulletSpawn;
    [SerializeField] protected float recoilForce;

    private Rigidbody rb;
    private XRGrabInteractable interactableWeapon;

    protected void Awake()
    {
        interactableWeapon = GetComponent<XRGrabInteractable>();
        rb = GetComponent<Rigidbody>();
        SetupInteractableWeaponEvents();
    }

    private void SetupInteractableWeaponEvents()
    {
        interactableWeapon.selectEntered.AddListener(PickUpWeapon);
        interactableWeapon.selectExited.AddListener(DropWeapon);
        interactableWeapon.activated.AddListener(StartShooting);
        interactableWeapon.deactivated.AddListener(StopShooting);
    }

    private void PickUpWeapon(SelectEnterEventArgs interactor)
    {
        
    }

    private void DropWeapon(SelectExitEventArgs interactor)
    {
        
    }
    
    protected virtual void StartShooting(ActivateEventArgs interactor)
    {
        
    }
    
    protected virtual void StopShooting(DeactivateEventArgs interactor)
    {
        
    }

    protected virtual void Shoot()
    {
        ApplyRecoil();
    }

    private void ApplyRecoil()
    {
        rb.AddRelativeForce(Vector3.back * recoilForce, ForceMode.Impulse);
    }

    public float GetShootingForce()
    {
        return shootingForce;
    }
}