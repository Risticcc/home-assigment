using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stall : MonoBehaviour
{
   private void OnTriggerEnter2D(Collider2D other)
   {
      if(other.CompareTag("Player"))
      {
         UIManager.Instance.OpenInventoryPanel();
      }
   }
}
