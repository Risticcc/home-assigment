using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{

   [SerializeField] private float radius;  //radius for interaction with objects
   [SerializeField] private LayerMask interactionObjectLayer;
   private Collider2D[] _collisions;
   private int _collisionCount = 0;
   private Rigidbody2D _rigidbody;
   

   public float Radius
   {
      get => radius;
      set => radius = value;
   }
   
   private void Start()
   {
      _rigidbody = GetComponent<Rigidbody2D>();
   }

   private void Update()
   {

      _collisions = Physics2D.OverlapCircleAll(transform.position, radius, interactionObjectLayer);
      
      foreach (var collider in _collisions)
      {
         BaseInteract interactableObject;
         if(collider.TryGetComponent<BaseInteract>(out interactableObject))
            interactableObject.Interact(this.gameObject);
      }
   }

   private void OnDrawGizmos()
   {
      Gizmos.color = Color.red;
      Gizmos.DrawWireSphere(transform.position, radius);
   }
}
