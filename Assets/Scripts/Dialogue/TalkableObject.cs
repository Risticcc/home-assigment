using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TalkableObject : BaseInteract
{
    [SerializeField] private string propmtText = "Press 'E' to talk";
    [SerializeField] private GameObject interactionPanel;
    [SerializeField] private float detectionRange = 3f;
    
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
            _dialogueTrigger.TriggerDialogue();
        }
    }


    private void Update()
    {
        if (PromptShown)
        {
            _hits = Physics2D.OverlapCircleAll(transform.position, detectionRange);
            foreach (var collider in _hits)
            {
                if(collider.gameObject.CompareTag("Player"))
                    return;
            }
            PromptShown = false;
        }
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRange);
    }
}
