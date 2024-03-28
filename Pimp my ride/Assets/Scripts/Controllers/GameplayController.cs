using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameplayController", menuName = "MVC_Controllers/GameplayController", order = 0)]
public class GameplayController : ScriptableObject
{
    public event Action<float, int> OnHealthUpdate;
    public event Action<int, NextAreaSelectZone> OnNextAreaSelectZoneEnter;
    public event Action<Vector3> OnNextAreaOpen;
   
    public void HandleHealthUpdate(float amount, int healthId)
    {
        OnHealthUpdate?.Invoke(amount, healthId);
    }

    public void HandlePlayerEnterSelectZone(int index, NextAreaSelectZone sender)
    {
        OnNextAreaSelectZoneEnter?.Invoke(index, sender);
    }

    public void HandleOpenNextArea(Vector3 doorRotation)
    {
        Debug.Log($"Check rotation {doorRotation}");
        if (doorRotation == Vector3.zero) 
        {
            Debug.Log($"Go to top");
            var nextAreaPosOffset = new Vector3(0, 0, 30f);//Top wall
            OnNextAreaOpen?.Invoke(nextAreaPosOffset);
            return;
        }
        if (doorRotation.y == 180f)
        {
            Debug.Log($"Go to bot");
            var nextAreaPosOffset = new Vector3(0, 0f, -30f);//Bot wall
            OnNextAreaOpen?.Invoke(nextAreaPosOffset);
            return;
        }
        if (doorRotation.y == 90f)
        {
            Debug.Log($"Go to right");
            var nextAreaPosOffset = new Vector3(30f, 0, 0f);//Right wall
            OnNextAreaOpen?.Invoke(nextAreaPosOffset);
            return;
        }
        else
        {
            Debug.Log($"Go to left");
            var nextAreaPosOffset = new Vector3(-30f, 0, 0f);//Left wall
            OnNextAreaOpen?.Invoke(nextAreaPosOffset);
        }
    }
}
