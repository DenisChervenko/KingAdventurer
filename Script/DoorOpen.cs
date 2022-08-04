using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class DoorOpen : MonoBehaviour
{
    [SerializeField] private float _distanceTeleport;
    [SerializeField] private GameObject _openDoorButton;

    // 1 - up
    // 2 - down
    // 3 - left
    // 4 - right
    // 0 - null
    private int _direction;

    [Inject] PlayerMovement playerMovement;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("leftDirection") || other.gameObject.CompareTag("rightDirection") ||
        other.gameObject.CompareTag("upDirection") || other.gameObject.CompareTag("downDirection"))
        {
            _openDoorButton.SetActive(true);

            _direction = other.gameObject.CompareTag("upDirection") == true ? 1 : other.gameObject.CompareTag("downDirection") == true ? 2 : 
            other.gameObject.CompareTag("leftDirection") == true ? 3 : other.gameObject.CompareTag("rightDirection") == true ? 4 : 0;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("leftDirection") || other.gameObject.CompareTag("rightDirection") ||
        other.gameObject.CompareTag("upDirection") || other.gameObject.CompareTag("downDirection"))
        {
            _openDoorButton.SetActive(false);
            _direction = 0;
        }
    }

    public void OnClickTeleportPlayer()
    {
        playerMovement.ColliderDisabled(false);

        if(_direction != 0)
        {
            Vector3 direction = Vector3.MoveTowards(gameObject.transform.position, new Vector3(_direction == 3 ? _distanceTeleport : _direction == 4 ? -_distanceTeleport : 0, 0, 
            _direction == 1 ? -_distanceTeleport : _direction == 2 ? _distanceTeleport : 0), 5);

            gameObject.transform.position = direction;
        }       

        playerMovement.ColliderDisabled(true);
        playerMovement.AnimatorState("Idle");

        _openDoorButton.SetActive(false);
    }
}
