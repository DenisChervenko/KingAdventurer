using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayInterstedPointInfo : MonoBehaviour
{
    [SerializeField] private TMP_Text _name;
    [SerializeField] private TMP_Text _description;

    [SerializeField] private GameObject _descriptioScreen;
    [SerializeField] private GameObject _inventory;

    [SerializeField] private PointsOfInterest pointsOfInterest;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            _name.text = pointsOfInterest.objectName;
            _description.text = pointsOfInterest.objectDescription;

            _descriptioScreen.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            _descriptioScreen.SetActive(false);
        }
    }
}
