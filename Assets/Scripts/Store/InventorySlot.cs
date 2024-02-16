using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private TextMeshProUGUI price; 
    [SerializeField] private TextMeshProUGUI itemName;
    [SerializeField] private Image defaultImage;
    
    private Item _item;
    public Item Item => _item;
    

    public void UpdateSlot(Item item)
    {
        _item = item;
        
        image.sprite = item.icon;
        price.text = item.price.ToString();
        itemName.text = item.name;
    }

    public void ClearSlot()
    {
        _item = null;
        
        //image.sprite = defaultImage.sprite;
        itemName.text = ""; 
        price.text = "";
    }
}
