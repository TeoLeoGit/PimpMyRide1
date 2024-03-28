using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class FlameThrower : Trap
{
    [Header("MVC_Controller")]
    [SerializeField] GameplayController _gameController;

    [SerializeField] Collider _gunCollider;
    [SerializeField] float _damageRange;
    [SerializeField] float _attackRate;
    [SerializeField] float _cooldownEachAttack;

    RaycastHit[] _hitInfos = { };

    private void Start()
    {
        Auto();
    }

    public override void Auto()
    {
        base.Auto();
        StartCoroutine(ILoopAttack());
    }

    private IEnumerator ILoopAttack()
    {
        while (true) 
        { 
            //Attack
            yield return new WaitForSeconds(_attackRate);
            _hitInfos = Physics.RaycastAll(_gunCollider.bounds.center, transform.forward, _damageRange, _damageableLayer);
            foreach(var hitInfo in _hitInfos) 
            {
                _gameController.HandleHealthUpdate(-baseDamage, hitInfo.rigidbody.gameObject.GetInstanceID());
            }
            
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        //Check if there has been a hit yet
        if (_hitInfos.Length > 0)
        {
            //Draw a Ray forward from GameObject toward the hit
            Gizmos.DrawRay(_gunCollider.bounds.center, transform.forward * _hitInfos[0].distance);
        }
        //If there hasn't been a hit yet, draw the ray at the maximum distance
        else
        {
            //Draw a Ray forward from GameObject toward the maximum distance
            Gizmos.DrawRay(_gunCollider.bounds.center, transform.forward * _damageRange);
        }
    }
}
