using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Equip : MonoBehaviour
{
    [SerializeField] private Button _button;
    private Store _store;
    
    void Start()
    {
      //  _store = FindObjectOfType<Store>();
        
        _button.onClick.AddListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        //_store.SellItem(this.gameObject);
    }
}
