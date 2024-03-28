using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallManager : MonoBehaviour
{
    [SerializeField] GameObject[] _verticalWalls;
    [SerializeField] GameObject[] _horizontalWalls;
    [SerializeField] DoorToNextArea[] _nextAreaDoors;

    private void Start()
    {
        StartCoroutine(Test());
    }

    private void ShowWallsToNextArea()
    {
        var random = Random.Range(0, 2);

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

    IEnumerator Test()
    {
        while (true)
        {
            yield return new WaitForSeconds(2f);
            SetupWalls();
            ShowWallsToNextArea();
            break;
        }
    }
}
