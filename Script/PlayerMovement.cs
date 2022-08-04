using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private GameObject _playerParent;
    [SerializeField] private GameObject _player;
    [SerializeField] private LayerMask _layerMask;

    [SerializeField] private ParticleSystem _particleClick;

    private float _distance;
    private bool _wasClickOnGround = false;    
    
    private BoxCollider _boxCollider;
    private Animator _animator;
    private Camera _cam;
    private NavMeshAgent _agent;

    RaycastHit _hit;

    private void Start()
    {
        _boxCollider = _playerParent.GetComponent<BoxCollider>();
        _animator = _player.GetComponent<Animator>();
        _cam = Camera.main;
        _agent = _playerParent.GetComponent<NavMeshAgent>();


        _particleClick.transform.position = _player.transform.position;
        _hit.point = _player.transform.position;
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = _cam.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray, out _hit, 200, _layerMask))
            {
                _agent.SetDestination(_hit.point);

                _particleClick.transform.position = _hit.point;
                _particleClick.Play();

                _wasClickOnGround = true;
            } 
        }

        if(_wasClickOnGround)
        {
            _distance = Vector3.Distance(_hit.point, _playerParent.transform.position);
        }

        _animator.SetTrigger(_distance > 0.5f ? "Walk" : "Idle");

        if(_distance < 0.5f)
        {
            _agent.isStopped = true;
            _agent.ResetPath();

            _wasClickOnGround = false;
        }
    }

    public void ColliderDisabled(bool willDisable)
    {
        _boxCollider.enabled = willDisable;

        _agent.isStopped = true;
        _agent.ResetPath();

        _wasClickOnGround = false;

        _animator.SetTrigger("Idle");
    }   

    public void AnimatorState(string animatorTriggerName)
    {
        _animator.SetTrigger(animatorTriggerName);
    }
}

