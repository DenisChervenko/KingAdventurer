using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("downDirection") || other.gameObject.CompareTag("upDirection"))
        {
            GameObject temp = other.gameObject;
            temp.SetActive(false);
        }
    }
}
