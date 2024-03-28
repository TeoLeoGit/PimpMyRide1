using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [Header("MVC_Controller")]
    [SerializeField] GameplayController _gameController;

    [SerializeField] GameObject _currentArea;
    [SerializeField] GameObject _nextArea;

    [SerializeField] WallManager _currentWallManager;
    [SerializeField] WallManager _nextWallManager;

    private void Start()
    {
        _gameController.OnNextAreaOpen += OpenNextArea;
        _gameController.OnPlayerEnterNewArea += OnPlayerEnterNewArea;

        StartCoroutine(Test());
    }

    IEnumerator Test()
    {
        yield return new WaitForSeconds(6f);
        _currentWallManager.ShowZonesTriggerNextArea();
    }

    private void OnDestroy()
    {
        _gameController.OnNextAreaOpen -= OpenNextArea;
        _gameController.OnPlayerEnterNewArea -= OnPlayerEnterNewArea;

    }

    private void OpenNextArea(Vector3 areaOffset)
    {
        _nextArea.SetActive(true);
        _nextArea.transform.position = _currentArea.transform.position + areaOffset;

        _nextWallManager.DeactiveWall(areaOffset);
    }

    private void OnPlayerEnterNewArea()
    {
        _nextWallManager.SetupWalls();
        _currentWallManager.SetupWalls();
        _currentArea.SetActive(false);

        var prevArea = _currentArea;
        var prevWallManager = _currentWallManager;

        _currentArea = _nextArea;
        _currentWallManager = _nextWallManager;
        _nextArea = prevArea;
        _nextWallManager = prevWallManager;

        StartCoroutine(Test());
    }
}
