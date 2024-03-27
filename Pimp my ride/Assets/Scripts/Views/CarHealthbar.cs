using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarHealthbar : MonoBehaviour
{
    Transform _camera;
    [SerializeField] Slider _rightHealthSlider;
    [SerializeField] Slider _leftHealthSlider;
    [SerializeField] Slider _rightShieldSlider;
    [SerializeField] Slider _leftShieldSlider;

    [SerializeField] HealthSystem _healthSystem;

    private void Awake()
    {
        _camera = Camera.main.transform;
        _healthSystem.OnHealthChange += UpdateHealthBar;
    }

    private void OnDestroy()
    {
        _healthSystem.OnHealthChange -= UpdateHealthBar;
    }

    private void LateUpdate()
    {
        transform.LookAt(transform.position + _camera.forward);
    }

    private void UpdateHealthBar(float currentHealth, float maxHealth)
    {
        float sliderValue = currentHealth / maxHealth;
        if (sliderValue >= 0.5f) //Right slider
        {
            var rightSliderValue = sliderValue - 0.5f;
            _rightHealthSlider.value = rightSliderValue * 2;
        }
        else
        {
            var leftSliderValue = sliderValue * 2;
            _leftHealthSlider.value = leftSliderValue;
            _rightHealthSlider.value = 0f;

        }
    }
}
