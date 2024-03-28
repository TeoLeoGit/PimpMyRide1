using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    [SerializeField] protected float baseDamage;
    [SerializeField] protected LayerMask _damageableLayer;

    public virtual void Attack() { }
    public virtual void Stop() { }
    public virtual void Auto() { }
}
