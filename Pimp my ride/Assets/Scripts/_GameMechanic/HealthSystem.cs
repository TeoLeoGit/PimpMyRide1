using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] GameplayController _gameController;
    [SerializeField] float _maxHealth;

    [SerializeField] private int _healthId;
    private float _currentHealth;

    public event Action<float, float> OnHealthChange;

    void Start()
    {
        _gameController.OnHealthUpdate += OnHealthUpdate;

        _currentHealth = _maxHealth;
        _healthId = gameObject.GetInstanceID();
    }

    private void OnDestroy()
    {
        _gameController.OnHealthUpdate -= OnHealthUpdate;

    }

    private void OnHealthUpdate(float amount, int healthId)
    {
        if (healthId == _healthId) 
        {
            _currentHealth = Mathf.Clamp(_currentHealth + amount, 0, _maxHealth);
            OnHealthChange?.Invoke(_currentHealth, _maxHealth);
            if (_currentHealth == 0f)
            {
                //Die event.
            }
        }
    }
}
