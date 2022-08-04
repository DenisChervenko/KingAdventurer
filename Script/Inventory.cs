using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private GameObject _itemInfo;
    [SerializeField] private GameObject[] _item;
    [SerializeField] private GameObject[] _itemIcon;

    [SerializeField] private GameObject[] _cell;

    [HideInInspector]
    public bool knifeTaked = false;
    [HideInInspector]
    public bool keyTaked = false;

    public int turnCell;
    public int[] cellIsEmpty;

    // 0 - key
    // 1 - knife
    public void TakeItem(int item)
    {
        if(cellIsEmpty[turnCell] == 0)
        {
            if(knifeTaked)
            {
                item = 0;
            }
            else if(keyTaked)
            {
                item = 1;
            }

            if(item == 1)
            {
                knifeTaked = true;
            }
            else if(item == 0)
            {
                keyTaked = true;
            }

            cellIsEmpty[turnCell] = 1;

            _itemIcon[item].transform.SetParent(_cell[turnCell].transform);
            _itemIcon[item].transform.localPosition = Vector3.zero;
            _itemIcon[item].SetActive(true);

            _item[item].SetActive(false);
            _itemInfo.SetActive(false);

            turnCell++;

            Debug.Log(item);
        }
    }

    public void DeletUsedItem(int itemIndex)
    {
        _itemIcon[itemIndex].transform.SetParent(null);
        _itemIcon[itemIndex].SetActive(false);

        turnCell = 0;
        cellIsEmpty[turnCell] = 0;
    }
}
