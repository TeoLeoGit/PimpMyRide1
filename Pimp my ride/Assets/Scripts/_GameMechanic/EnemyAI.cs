using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform _target;
    [SerializeField] Collider _collider;
    [SerializeField] float _maxDistance;
    [SerializeField] Vector3 _rayBoxSize;
    bool _hitDetect;
    RaycastHit _hit;
    CarController _carController;
    public float steerAngle;
    // Start is called before the first frame update
    void Start()
    {
        _carController = GetComponent<CarController>();
    }

    void Update()
    {
        CheckWalls();
    }

    private void FixedUpdate()
    {
    }

    private void CheckWalls()
    {
        RaycastHit hitInfo;
        _hitDetect = Physics.Raycast(_collider.bounds.center, transform.forward, out hitInfo, _maxDistance);
        if (_hitDetect && hitInfo.collider.name == "Wall")
        {
            //Output the name of the Collider your Box hit
            _carController.MoveBack(steerAngle);
        }
        else
        {
            _carController.SteeringToTarget(_target.position);
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        //Check if there has been a hit yet
        if (_hitDetect)
        {
            //Draw a Ray forward from GameObject toward the hit
            Gizmos.DrawRay(transform.position, transform.forward * _hit.distance);
        }
        //If there hasn't been a hit yet, draw the ray at the maximum distance
        else
        {
            //Draw a Ray forward from GameObject toward the maximum distance
            Gizmos.DrawRay(transform.position, transform.forward * _maxDistance);
        }
    }

}
