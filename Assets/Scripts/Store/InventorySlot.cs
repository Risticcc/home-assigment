using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class InventorySlot : MonoBehaviour
{
    [SerializeField] private Sprite image;
    [SerializeField] private TextMeshProUGUI price; 
    [SerializeField] private TextMeshProUGUI itemName;
    [SerializeField] private Sprite defaultImage;
    
    private Item _item;
    public Item Item => _item;
    

    public void UpdateSlot(Item item)
    {
        _item = item;
        
        image = item.icon;
        price.text = item.price.ToString();
        itemName.text = item.name;
    }

    public void ClearSlot()
    {
        _item = null;
        
        image = defaultImage;
        itemName.text = ""; 
        price.text = "";
    }
}
