using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameplayController", menuName = "MVC_Controllers/GameplayController", order = 0)]
public class GameplayController : ScriptableObject
{
    public event Action<float, int> OnHealthUpdate;
    public event Action<int, NextAreaSelectZone> OnNextAreaSelectZoneEnter;
   

    public void HandleHealthUpdate(float amount, int healthId)
    {
        OnHealthUpdate?.Invoke(amount, healthId);
    }

    public void HandlePlayerEnterSelectZone(int index, NextAreaSelectZone sender)
    {
        OnNextAreaSelectZoneEnter?.Invoke(index, sender);
    }


}
