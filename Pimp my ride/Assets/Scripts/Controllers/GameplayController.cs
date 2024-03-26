using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameplayController", menuName = "MVC_Controllers/GameplayController", order = 0)]
public class GameplayController : ScriptableObject
{
    public event Action<float, int> OnHealthUpdate;
    private void Awake()
    {
        
    }

    private void OnDestroy()
    {
        
    }

    public void HandleHealthUpdate(float amount, int healthId)
    {
        OnHealthUpdate?.Invoke(amount, healthId);
    }
}
