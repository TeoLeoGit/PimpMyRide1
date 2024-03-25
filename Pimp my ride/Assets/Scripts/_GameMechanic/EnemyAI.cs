using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform _target;
    CarController _carController;
    // Start is called before the first frame update
    void Start()
    {
        _carController = GetComponent<CarController>();
    }

    void Update()
    {
        _carController.SteeringToTarget(_target.position);
    }

    private void FixedUpdate()
    {
    }
}
