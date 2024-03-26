using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : Trap
{
    [Header("MVC_Controller")]
    [SerializeField] GameplayController _gameController;

    [Space(10)]
    [SerializeField] float _rotateDuration;
    [SerializeField] float _damageCooldown;

    private void Start()
    {
        Auto();
    }

    public override void Auto()
    {
        transform.DORotate(new Vector3(0, 90f, 0), _rotateDuration).SetLoops(-1, LoopType.Restart).SetEase(Ease.Linear);
    }

    private void OnCollisionEnter(Collision collision)
    {
        var layer = collision.collider.gameObject.layer;
        if (layer == 9 || layer == 10)
        {
            _gameController.HandleHealthUpdate(-baseDamage, collision.gameObject.GetInstanceID());
        }
    }
}
