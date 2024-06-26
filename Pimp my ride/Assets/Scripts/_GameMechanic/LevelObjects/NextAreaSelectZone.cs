using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextAreaSelectZone : MonoBehaviour
{
    [Header("MVC_Controller")]
    [SerializeField] GameplayController _gameController;

    [Space(10)]
    [SerializeField] LayerMask _playerLayer;
    [SerializeField] int _index;

    private void OnTriggerEnter(Collider other)
    {
        if (((1 << other.gameObject.layer) & _playerLayer) != 0)
        {
            _gameController.HandlePlayerEnterSelectZone(_index, this);
            GetComponent<Collider>().enabled = false;
            StartCoroutine(ICloseOldArea());
        }
    }

    private IEnumerator ICloseOldArea()
    {
        yield return new WaitForSeconds(4f);
        gameObject.SetActive(false);
        GetComponent<Collider>().enabled = true;
        _gameController.HandlePlayerEnterNewArea();
    }
}
