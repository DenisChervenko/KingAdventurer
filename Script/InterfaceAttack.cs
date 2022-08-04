using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class InterfaceAttack : MonoBehaviour
{
    [SerializeField] private GameObject _endScreen;

    public Image _timeLine;
    [SerializeField] private GameObject _interfaceAttack;
    [SerializeField] private GameObject _inventory;
    [SerializeField] private float _timeBetwenWakeUp;

    private float _elapsedTime;

    private bool _wasMeetEnemy = false;

    [Inject] WarriorMoveLogic warriorMoveLogic;

    private void Update()
    {
        if(_wasMeetEnemy)
        {
            _timeLine.fillAmount += 1.0f/_timeBetwenWakeUp * Time.deltaTime;

            _elapsedTime += Time.deltaTime;
            if(_elapsedTime >= _timeBetwenWakeUp)
            {
                _timeLine.fillAmount = 0;
                _endScreen.SetActive(true);

                _wasMeetEnemy = false;
            }
        }
    }

    public void InterfaceAttackAction(bool show)
    {
        _interfaceAttack.SetActive(show);
        _inventory.SetActive(show == true ? false : true);
        _wasMeetEnemy = show;
    }
}
