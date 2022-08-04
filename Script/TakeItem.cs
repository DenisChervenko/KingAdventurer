using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeItem : MonoBehaviour
{
    [SerializeField] private GameObject _buttonForTakeKey;
    [SerializeField] private GameObject _buttonForTakeKnife;
    
    [SerializeField] private GameObject _itemInfo;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Key"))
        {
            _buttonForTakeKey.SetActive(true);
        
            _itemInfo.SetActive(true);
        }

        if(other.gameObject.CompareTag("Knife"))
        {
            _buttonForTakeKnife.SetActive(true);

            _itemInfo.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        _buttonForTakeKey.SetActive(false);
        _itemInfo.SetActive(false);
    }
}
