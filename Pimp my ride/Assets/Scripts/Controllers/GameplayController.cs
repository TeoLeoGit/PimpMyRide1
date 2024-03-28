using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameplayController", menuName = "MVC_Controllers/GameplayController", order = 0)]
public class GameplayController : ScriptableObject
{
    public event Action<float, int> OnHealthUpdate;
    public event Action<int, NextAreaSelectZone> OnNextAreaSelectZoneEnter;
    public event Action OnPlayerEnterNewArea;
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
        if (doorRotation == Vector3.zero) 
        {
            var nextAreaPosOffset = new Vector3(0, 0, 30f);//Top wall
            OnNextAreaOpen?.Invoke(nextAreaPosOffset);
            return;
        }
        if (doorRotation.y == 180f)
        {
            var nextAreaPosOffset = new Vector3(0, 0f, -30f);//Bot wall
            OnNextAreaOpen?.Invoke(nextAreaPosOffset);
            return;
        }
        if (doorRotation.y == 90f)
        {
            var nextAreaPosOffset = new Vector3(30f, 0, 0f);//Right wall
            OnNextAreaOpen?.Invoke(nextAreaPosOffset);
            return;
        }
        else
        {
            var nextAreaPosOffset = new Vector3(-30f, 0, 0f);//Left wall
            OnNextAreaOpen?.Invoke(nextAreaPosOffset);
        }
    }

    public void HandlePlayerEnterNewArea()
    {
        OnPlayerEnterNewArea?.Invoke();
    }
}
