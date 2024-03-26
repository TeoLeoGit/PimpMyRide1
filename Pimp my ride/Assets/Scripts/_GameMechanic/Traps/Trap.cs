using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    [SerializeField] float _baseDamage;

    public virtual void Attack() { }
    public virtual void Stop() { }

    public virtual void Auto() { }
}
