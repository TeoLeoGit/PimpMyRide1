using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Hammer : Trap
{
    [SerializeField] float _rotateValue;
    [SerializeField] float _rotateDuration;
    [SerializeField] float _delayTime;

    private bool _enableDamage;
    private void Start()
    {
        Auto();
    }

    public override void Attack()
    {
        base.Attack();
        transform.DORotate(new Vector3(_rotateValue, 0, 0), _rotateDuration);
    }

    public override void Auto()
    {
        base.Auto();
        StartCoroutine(ILoopAttack());
    }

    private IEnumerator ILoopAttack()
    {
        yield return new WaitForSeconds(_delayTime);
        _enableDamage = true;
        transform.DORotate(new Vector3(_rotateValue, 0, 0), _rotateDuration)
            .OnComplete(() =>
            {
                _enableDamage = false;
                StartCoroutine(ILiftHammerUp());
            });
    }

    private IEnumerator ILiftHammerUp()
    {
        yield return new WaitForSeconds(_delayTime);
        transform.DORotate(new Vector3(0, 0, 0), _rotateDuration)
                .OnComplete(() =>
                {
                    StartCoroutine(ILoopAttack());
                });
    }

    public override void Stop()
    {
        StopAllCoroutines();
    }
}
