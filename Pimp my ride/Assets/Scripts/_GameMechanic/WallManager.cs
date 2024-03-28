using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallManager : MonoBehaviour
{
    [SerializeField] GameObject[] _verticalWalls; //0 = right, 1 = left.
    [SerializeField] GameObject[] _horizontalWalls; //0 = top, 1 = bot.
    [SerializeField] DoorToNextArea[] _nextAreaDoors;

    public void ShowZonesTriggerNextArea()
    {
        //var random = Random.Range(0, 2);
        var random = 0;

        if (random == 0)
        {
            _nextAreaDoors[0].transform.localPosition = _verticalWalls[0].gameObject.transform.localPosition;
            _nextAreaDoors[0].transform.localRotation = _verticalWalls[0].gameObject.transform.localRotation;
            _verticalWalls[0].gameObject.SetActive(false);
            _nextAreaDoors[0].SetupDoors();

            _nextAreaDoors[1].transform.localPosition = _verticalWalls[1].gameObject.transform.localPosition;
            _nextAreaDoors[1].transform.localRotation = _verticalWalls[1].gameObject.transform.localRotation;
            _verticalWalls[1].gameObject.SetActive(false);
            _nextAreaDoors[1].SetupDoors();
        }
        else
        {
            _nextAreaDoors[0].transform.localPosition = _horizontalWalls[0].gameObject.transform.localPosition;
            _nextAreaDoors[0].transform.localRotation = _horizontalWalls[0].gameObject.transform.localRotation;
            _horizontalWalls[0].gameObject.SetActive(false);
            _nextAreaDoors[0].SetupDoors();


            _nextAreaDoors[1].transform.localPosition = _horizontalWalls[1].gameObject.transform.localPosition;
            _nextAreaDoors[1].transform.localRotation = _horizontalWalls[1].gameObject.transform.localRotation;
            _horizontalWalls[1].gameObject.SetActive(false);
            _nextAreaDoors[1].SetupDoors();
        }
    }

    private void SetupWalls()
    {
        foreach(var wall in _horizontalWalls) 
            wall.SetActive(true);
        foreach (var wall in _verticalWalls)
            wall.SetActive(true);
    }

    public void DeactiveWall(Vector3 areaOffset)
    {
        if (areaOffset.z == 30f) //Place area on top --> deactive bot wall
        {
            _horizontalWalls[1].SetActive(false);
            return;
        }
        if (areaOffset.z == -30f) 
        {
            _horizontalWalls[0].SetActive(false);
            return;
        }
        if (areaOffset.x == 30f) 
        {
            _verticalWalls[1].SetActive(false);
            return;
        }
        _verticalWalls[0].SetActive(false);
    }
}
