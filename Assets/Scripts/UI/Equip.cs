using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Equip : MonoBehaviour
{
    [SerializeField] private Button _button;
    
    private OutfitManager _player;
    private InventorySlot _inventorySlot;
    
    
    void Start()
    {   
        _player = FindObjectOfType<OutfitManager>();  
        
        _inventorySlot = GetComponent<InventorySlot>();
        _button.onClick.AddListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        if (_inventorySlot.Item != null)
        {
            _player.ChangeOutfit(_inventorySlot.Item.itemId);
            UIManager.Instance.RefreshPlayerPanel();
        }
    }
}
