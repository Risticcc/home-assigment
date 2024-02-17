using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryWarderobe : MonoBehaviour
{
    [SerializeField] private List<Item> items = new List<Item>();
    [SerializeField] private List<InventorySlot> slots = new List<InventorySlot>();
    [SerializeField] private float size;
    
    [SerializeField] private GameObject inventoryUI;
    [SerializeField] private GameObject slotUIPrefab;

    public void Awake()
    {
        InitaliseSlots();
    }

    public void AddItem(Item item)
    {
        items.Add(item);
        var index = items.IndexOf(item);
        Debug.Log(index);
        slots[index].UpdateSlot(item);
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
            
            slots.Add(invSlot); 
        }
    }
}
