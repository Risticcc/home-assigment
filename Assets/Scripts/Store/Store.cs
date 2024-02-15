using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Store : MonoBehaviour
{
    [SerializeField] private float _money = 0;
    
    [SerializeField] private List<Item> items = new List<Item>();
    [SerializeField] private List<InventorySlot> slots = new List<InventorySlot>();
    [SerializeField] private float size;
    
    [SerializeField] private GameObject slotUIPrefab;
    [SerializeField] private GameObject inventoryUI;
    [SerializeField] private Image merchantImage;
    [SerializeField] private TextMeshProUGUI merchantText;
    [SerializeField] private NPC merchant;
 
    public void SellItem(Item item)
    {
        if (items.Contains(item))
        {
            _money += item.price;
            RemoveItem(item);
        }
    }
    
    public void Start()
    {
        InitaliseSlots();
    }

    public void AddItem(Item item)
    {
        items.Add(item);
        slots[items.IndexOf(item)].UpdateSlot(item);
    }
    
    public void RemoveItem(Item item)
    {
        items.Remove(item);
        slots[items.IndexOf(item)].ClearSlot();
    }
    
    
    private void InitaliseSlots()
    {
        for(int i = 0; i< size; i++)
        {
            var slot = Instantiate(slotUIPrefab, inventoryUI.transform);
            var invSlot = slot.GetComponent<InventorySlot>();
            invSlot.ClearSlot();
            
            slots.Add(slot.GetComponent<InventorySlot>());
        }

        merchantImage.sprite = merchant.image;
        merchantText.text = merchant.storeDescription;
    }
    
}
