using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Landmine : Trap
{
    [Header("MVC_Controller")]
    [SerializeField] GameplayController _gameController;
    private bool _activated = false;

    private void OnCollisionEnter(Collision collision)
    {
        var layer = collision.collider.gameObject.layer;
        if (!_activated && (layer == 9 || layer == 10))
        {
            _activated = true;
            _gameController.HandleHealthUpdate(-baseDamage, collision.gameObject.GetInstanceID());
            Destroy(gameObject);
        }
    }
}
