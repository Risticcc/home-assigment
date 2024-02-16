using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    [SerializeField] private float money;
    [SerializeField] private TextMeshProUGUI moneyText;
    [SerializeField] private Inventory inventory;
    
    private void Start()
    {
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
            inventory.AddItem(item);
            
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
