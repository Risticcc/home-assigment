using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;


public class TalkableObject : BaseInteract
{
    [SerializeField] private string propmtText = "Press 'E' to talk";
    [SerializeField] private GameObject interactionPanel;
    [Tooltip("Activate ability to start dialogue again after it has been completed and player goes away from the object by a certain distance")]
    [SerializeField] private float range = 3f;
    
    private DialogueTrigger _dialogueTrigger;
    private Collider2D[] _hits;
    
    private void  Start()
    {
        base.Init(interactionPanel);
        
        _dialogueTrigger = GetComponent<DialogueTrigger>();
        
    }
    
    public override void Interact(GameObject gameObject)
    {
        if (!PromptShown)
        {
            base.ShowInteractionPanel();
        }


        if (Input.GetKeyDown(KeyCode.E))
        {
            base.HideInteractionPanel();
            _dialogueTrigger.TriggerDialogue(UseEvents);
        }
    }


    private void Update()
    {
        if (PromptShown)
        {
            _hits = Physics2D.OverlapCircleAll(transform.position, range);
            foreach (var collider in _hits)
            {
                if(collider.gameObject.CompareTag("Player"))
                    return;
            }
            PromptShown = false;
            _dialogueTrigger.CloseConversationUI();
        }
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
