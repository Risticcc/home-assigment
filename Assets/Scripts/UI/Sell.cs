using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sell : MonoBehaviour
{
    [SerializeField] private Button _button;
    private SellManager _sellManager;
    
    void Start()
    {
        _sellManager = FindObjectOfType<SellManager>();
        _button.onClick.AddListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        var item = GetComponent<InventorySlot>().Item;
        _sellManager.SellItem(item);
    }
}
