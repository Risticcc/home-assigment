
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SellManager : MonoBehaviour
{
    [SerializeField] private List<Item> items = new List<Item>(); //TODO another item
    [SerializeField] private List<InventorySlot> slots = new List<InventorySlot>();
    
    [SerializeField] private GameObject slotUIPrefab;
    [SerializeField] private GameObject storeInventoryUI;
    
    [SerializeField] private GameObject player;
    
    [SerializeField] private GameObject CoinsPanel;
    private Animator coinAnimator;
    
    private MoneyManager _moneyManager;

   

    private void Start()
    {
        InitaliseSlots();
        
        _moneyManager = player.GetComponent<MoneyManager>();
    }
    
    
    public void SellItem(Item item)
    {
        _moneyManager.AddMoney(item.price);
        
        var slot = slots.Find(slot => slot.Item == item);
        slots.Remove(slot);
        Destroy(slot.gameObject);
        
        items.Remove(item);
        
        
    }
    
    public void AddItem(Item item)
    {
        items.Add(item);
        
        var slot = Instantiate(slotUIPrefab, storeInventoryUI.transform);
        var invSlot = slot.GetComponent<InventorySlot>();
        invSlot.UpdateSlot(item);
        
        slots.Add(invSlot);
    }
    
   
    
    private void InitaliseSlots()
    {
        for(int i = 0; i< items.Count; i++)
        {
            var slot = Instantiate(slotUIPrefab, storeInventoryUI.transform);
            var invSlot = slot.GetComponent<InventorySlot>();
            invSlot.UpdateSlot(items[i]);
            
            slots.Add(invSlot);
        }
    }
    
    
    
    
    
}
