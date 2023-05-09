using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class PhysicsDamage : MonoBehaviour, ITakeDamage
{
    // Variables
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void TakeDamage(Weapon weapon, Projectile projectile, Vector3 contactPoint)
    {
        rb.AddRelativeForce(projectile.transform.forward * weapon.GetShootingForce(), ForceMode.Impulse);
    }
}
