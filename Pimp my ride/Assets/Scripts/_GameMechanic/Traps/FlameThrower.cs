using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameThrower : Trap
{
    [Header("MVC_Controller")]
    [SerializeField] GameplayController _gameController;

    [SerializeField] float _damageRange;
    [SerializeField] float _attackRate;
    [SerializeField] float _cooldownEachAttack;

    public override void Auto()
    {
        base.Auto();
        StartCoroutine(ILoopAttack());
    }

    private IEnumerator ILoopAttack()
    {
        yield return new WaitForSeconds(_cooldownEachAttack);
        //Attack
    }
}
