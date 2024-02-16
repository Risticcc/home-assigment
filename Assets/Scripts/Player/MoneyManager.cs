using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    [SerializeField] private float money;
    [SerializeField] private TextMeshProUGUI moneyText;
    
    private InventoryWarderobe _inventoryWarderobe;
    
    private void Start()
    {
        _inventoryWarderobe = GetComponent<InventoryWarderobe>();
        RefresUI();
    }
    
    
    public void AddMoney(int amount)
    {
        money += amount;
        RefresUI();
        Debug.Log("Added " + amount + " money. Total money: " + money);
    }

    // Method to deduct money from the player's wallet
    public bool SpendMoney(Item item)
    {
        var amount = item.price;
        if (money >= amount)
        {
            money -= amount;
            _inventoryWarderobe.AddItem(item);
            
            RefresUI();
            Debug.Log("Spent " + amount + " money. Total money: " + money);
            return true;
        }
        else
        {
            Debug.Log("Not enough money to spend " + amount);
            return false;
        }
    }

    // Method to get the current amount of money in the wallet
    public float GetMoney()
    {
        return money;
    }

    private void RefresUI()
    {
        moneyText.text = money.ToString();
    }
}
