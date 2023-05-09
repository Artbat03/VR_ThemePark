using UnityEngine;

public class Projectile : MonoBehaviour
{
    // Variables
    [SerializeField] protected Weapon _weapon;

    public virtual void Init(Weapon weapon)
    {
        this._weapon = weapon;
    }

    public virtual void Launch()
    {
        
    }
}
