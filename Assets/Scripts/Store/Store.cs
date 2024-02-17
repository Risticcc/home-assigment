
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
  
    
    [SerializeField] private GameObject slotUIPrefab;
    [SerializeField] private GameObject storeInventoryUI;
    
    [SerializeField] private Image merchantImage;
    [SerializeField] private TextMeshProUGUI merchantText;
    [SerializeField] private NPC merchant;
    
    [SerializeField] private Image playerImage;
    [SerializeField] private GameObject player;

    [SerializeField] private GameObject CoinsPanel;
    private Animator coinAnimator;
    
    public void SellItem(GameObject item)
    {
        var itemComponent = item.GetComponent<InventorySlot>();
        var moneyManager = player.GetComponent<MoneyManager>();

        if (!moneyManager.SpendMoney(itemComponent.Item))
        {
            coinAnimator.SetTrigger("OnClick");
            return;
        }

        if (items.Contains(itemComponent.Item))
        {
            _money += itemComponent.Item.price;
            Debug.Log("Sold " + itemComponent.name + " for " + itemComponent.Item.price);
            RemoveItem(itemComponent); //TODO totaly remove slot
        }
    }
    
    public void Start()
    {
        InitaliseSlots();
        
        UIManager.Instance.OnEquip += UpdatePlayerImage;
        coinAnimator = CoinsPanel.GetComponent<Animator>();
    }
    

    public void AddItem(Item item)
    {
        items.Add(item);
        slots[items.IndexOf(item)].UpdateSlot(item);
    }
    
    public void RemoveItem(InventorySlot item)
    {
        if(items.Contains(item.Item)){
            items.Remove(item.Item);
            var slot = slots.Find(slot => slot == item);
            slot.ClearSlot();
            Destroy(slot.gameObject);
        }
    }
    
    
    private void InitaliseSlots()
    {
        var currentOutfit = player.GetComponent<OutfitManager>().PlayerOutfitImage;
        for(int i = 0; i< items.Count; i++)
        {
            if(items[i].icon == currentOutfit) //Don't show the current outfit in the store
                continue; 
            
            var slot = Instantiate(slotUIPrefab, storeInventoryUI.transform);
            var invSlot = slot.GetComponent<InventorySlot>();
            invSlot.UpdateSlot(items[i]);
            
            slots.Add(invSlot);
            
        }

        
        UpdateMerchantInfo();
        UpdatePlayerImage();
    }

    private void UpdateMerchantInfo()
    {
        merchantImage.sprite = merchant.image;
        StartCoroutine(TypeSentence(merchant.storeDescription));
    }

    private void UpdatePlayerImage()
    {
        playerImage.sprite = player.GetComponent<OutfitManager>().PlayerOutfitImage;
    }

    private IEnumerator TypeSentence(string sentence)
    { 
        merchantText.text = "";
        foreach (var letter in sentence.ToCharArray())
        {
            merchantText.text += letter;
            yield return null;
        }
    }
    
    
}
