using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class WarriorMoveLogic : MonoBehaviour
{   
    [Header("GameObject")]
    [SerializeField] private GameObject _warriorParent;
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _playermovement;
    
    [Header("UI")]
    [SerializeField] private Image _fillAmount;
    public GameObject fillArea;

    private float _timeStan = 5f;
    private float _elapsedTime;
    
    [HideInInspector]
    public bool _warriorWasStaned = false;

    [HideInInspector]
    public Animator _animator;
    private BoxCollider _boxCollider;

    [Inject] InterfaceAttack interfaceAttack;

    private void Start()
    {
        _animator = gameObject.GetComponent<Animator>();
        _boxCollider = gameObject.GetComponent<BoxCollider>();
    }

    private void Update()
    {
        if(_warriorWasStaned)
        {
            _fillAmount.fillAmount += 1.0f/_timeStan * Time.deltaTime;
            _elapsedTime += Time.deltaTime;

            if(_elapsedTime >= _timeStan)
            {
                _boxCollider.enabled = true;
                fillArea.SetActive(false);

                _elapsedTime = 0;
                _fillAmount.fillAmount -= 1.0f;

                _warriorWasStaned = false;
            }
        }   
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            _boxCollider.enabled = false;
            _playermovement.SetActive(false);

            interfaceAttack.InterfaceAttackAction(true);
        }
    }

    public void Die()
    {
        _warriorParent.SetActive(false);
    }

    public void PlayerMovementScript(bool active)
    {
        _playermovement.SetActive(active);
    }
}
