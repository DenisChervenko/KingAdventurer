using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using Zenject;

public class EndGame : MonoBehaviour
{
    [Inject] Inventory inventory;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Lock"))
        {
            if(inventory.keyTaked)
            {
                SceneManager.LoadScene(0);
            }
        }
    }
}
