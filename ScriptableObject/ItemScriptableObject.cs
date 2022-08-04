using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", order = 51)]
public class ItemScriptableObject : ScriptableObject
{
    public Sprite icon;
    
    public string name;
    public string damage;

    public string description;
}
