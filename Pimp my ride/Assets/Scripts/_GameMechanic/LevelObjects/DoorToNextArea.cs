using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorToNextArea : MonoBehaviour
{
    [Header("MVC_Controller")]
    [SerializeField] GameplayController _gameController;

    [SerializeField] List<GameObject> _doors;
    [SerializeField] List<NextAreaSelectZone> _selectZones;

    private void Start()
    {
        _gameController.OnNextAreaSelectZoneEnter += OnPlayerSelectDoor;

        gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        _gameController.OnNextAreaSelectZoneEnter -= OnPlayerSelectDoor;
    }

    private void OnPlayerSelectDoor(int doorIndex, NextAreaSelectZone sender)
    {
        if (_selectZones.Contains(sender))
        {
            _doors[doorIndex].gameObject.SetActive(false);
            _selectZones[doorIndex].gameObject.SetActive(false);
            _gameController.HandleOpenNextArea(transform.localRotation.eulerAngles);
        }
    }

    public void SetupDoors()
    {
        gameObject.SetActive(true);
        foreach (var door in _doors)
            door.SetActive(true);

        int randomZone = Random.Range(0, _selectZones.Count);
        foreach (var selectZone in _selectZones)
            selectZone.gameObject.SetActive(false);
        _selectZones[randomZone].gameObject.SetActive(true);
    }
}
