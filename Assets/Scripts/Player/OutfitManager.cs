using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutfitManager : MonoBehaviour
{
    private GameObject _playerOutfitPrefab;
    
    private InventoryWarderobe _inventoryWarderobe;
    private Sprite _playerOutfitSprite;
    private PlayerController _playerController;
    public Sprite PlayerOutfitImage => _playerOutfitSprite;
    
    
    private void Start()
    {
        _playerController = GetComponent<PlayerController>();
        _inventoryWarderobe = GetComponent<InventoryWarderobe>();
        
        Init();
    }

    private void Init()
    {
        var activeOutfit = _playerController.FindActiveChild();
        if(activeOutfit != null)
        {
            _playerOutfitSprite = activeOutfit.GetComponent<PlayerInfo>().Item.icon;
            _inventoryWarderobe.AddItem(activeOutfit.GetComponent<PlayerInfo>().Item);
        }
    }

    public void ChangeOutfit(int id)
    {
        for(int i = 0; i< transform.childCount; i++)
        {
            PlayerInfo item = transform.GetChild(i).GetComponent<PlayerInfo>();
            
            if(item.Item.itemId == id)
            {
                transform.GetChild(i).gameObject.SetActive(true);
                _playerOutfitSprite = item.Item.icon;
                _playerController.AnimatorSetUp(); //because animator is attached to the exact prefab that represents the outfit
            }
            else
            {
                transform.GetChild(i).gameObject.SetActive(false);
            }
        }
    }
    
}
