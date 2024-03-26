using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    [SerializeField] protected float baseDamage;

    public virtual void Attack() { }
    public virtual void Stop() { }

    public virtual void Auto() { }
}
