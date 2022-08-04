using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DisplayInfo : MonoBehaviour
{
    [SerializeField] private Image _icon;
    [SerializeField] private TMP_Text _name;
    [SerializeField] private TMP_Text _damage;
    [SerializeField] private TMP_Text _description;

    [SerializeField] private ItemScriptableObject itemScriptableObject;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            _icon.sprite = itemScriptableObject.icon;
            _name.text = itemScriptableObject.name;
            _damage.text = itemScriptableObject.damage.ToString();
            _description.text = itemScriptableObject.description;
        }
    }
}
