using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    [SerializeField] private GameObject _chest;
    [SerializeField] private GameObject _openChestButton;
    [SerializeField] private GameObject _item;
    [SerializeField] private ParticleSystem _particleOpenChest;

    [SerializeField] private Transform[] _spawnPoint;

    private BoxCollider _boxCollider;
    private Animator _animator;

    private void Start()
    {
        _animator = gameObject.GetComponent<Animator>();
        _boxCollider = gameObject.GetComponent<BoxCollider>();

        gameObject.transform.position = _spawnPoint[Random.Range(0, _spawnPoint.Length)].position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            VisibilityButton(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            VisibilityButton(false);
        }
    }

    private void VisibilityButton(bool show)
    {
        _openChestButton.SetActive(show);
    }

    public void OpenChest()
    {
        _animator.SetTrigger("Open");
        _boxCollider.enabled = false;
        _openChestButton.SetActive(false);
    }

    public void EventAnimationShowItem()
    {
        _item.SetActive(true);
    }

    public void EventParticlePlay()
    {
        _particleOpenChest.Play();
    }
}
