using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialActivate : MonoBehaviour
{
    [SerializeField] private GameObject _tutorialScreen;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Tutorial"))
        {
            _tutorialScreen.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Tutorial"))
        {
            _tutorialScreen.SetActive(false);
        }
    }
}
