using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class PhysicsProjectile : Projectile
{
    [SerializeField] private float lifeTime;
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public override void Init(Weapon weapon)
    {
        base.Init(weapon);
        Destroy(gameObject, lifeTime);
    }

    public override void Launch()
    {
        base.Launch();
        rb.AddRelativeForce(Vector3.forward * _weapon.GetShootingForce(), ForceMode.Impulse);
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);

        ITakeDamage[] damageTakers = other.GetComponentsInChildren<ITakeDamage>();

        foreach (ITakeDamage taker in damageTakers)
        {
            taker.TakeDamage(_weapon, this, transform.position);
        }
    }
}
