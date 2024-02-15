using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    public string name;
    public float price;
    public Sprite icon = null;
    public GameObject prefab = null;
    
}
