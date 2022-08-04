using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class BattleScreen : MonoBehaviour
{
    [SerializeField] private GameObject _playerMovement;
    [SerializeField] private GameObject _keyDropItem;

    [SerializeField] private ParticleSystem _getDamage;
    [SerializeField] private ParticleSystem _killEnemy;
    [SerializeField] private ParticleSystem _stanedEnemy;

    [Inject] WarriorMoveLogic warriorMoveLogic;
    [Inject] Inventory inventory;
    [Inject] InterfaceAttack interfaceAttack;
    [Inject] PlayerHealth playerHealth;

    public void RunAway()
    {
        int chanceForRun = Random.Range(0, 3);

        if(chanceForRun == 0)
        {
            _getDamage.Play();
            playerHealth.GetDamage(0.5f);
        } 

        _stanedEnemy.Play();
        warriorMoveLogic._warriorWasStaned = true;
        warriorMoveLogic.fillArea.SetActive(true);
        warriorMoveLogic.PlayerMovementScript(true);
        interfaceAttack.InterfaceAttackAction(false);
        interfaceAttack._timeLine.fillAmount = 0;
    }

    public void AttackEnemy()
    {
        if(inventory.knifeTaked)
        {
            _killEnemy.Play();
            warriorMoveLogic._animator.SetTrigger("Die");

            inventory.DeletUsedItem(1);
            warriorMoveLogic.PlayerMovementScript(true);
            interfaceAttack.InterfaceAttackAction(false);
            _keyDropItem.SetActive(true);
        }
    }
}
