using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class PhysicsDamage : MonoBehaviour, ITakeDamage
{
    // Variables
    private Rigidbody rb;
    [SerializeField] private int targetPoints;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void TakeDamage(Weapon weapon, Projectile projectile, Vector3 contactPoint)
    {
        rb.useGravity = true;
        rb.AddRelativeForce(projectile.transform.forward * weapon.GetShootingForce(), ForceMode.Impulse);
        ScoreManager.instance.TunnelScore += targetPoints;
        Destroy(gameObject);
    }
}
