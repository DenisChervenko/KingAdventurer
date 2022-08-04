using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGridgeDestroy : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Destroyer"))
        {
            gameObject.SetActive(false);
        }
    }
}
