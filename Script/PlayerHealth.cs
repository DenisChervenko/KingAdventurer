using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private GameObject _endScreen;
    [SerializeField] private Image _healthImage;
    private float _health = 1.0f;

    [SerializeField] private GameObject[] _uiForHide;
    [SerializeField] private GameObject _playerMovement;

     public void GetDamage(float damage)
    {
        _healthImage.fillAmount -= damage;
        _health -= damage;
        EndGame();
    }

    public void GetHealth(float restoreHealth)
    {
        _healthImage.fillAmount += restoreHealth;
        _health += restoreHealth;
    }

    private void EndGame()
    {
        if(_health <= 0)
        {
            for(int i = 0; i <= (_uiForHide.Length - 1); i++)
            {
                _uiForHide[i].SetActive(false);
            }

            _playerMovement.SetActive(false);
            _endScreen.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
