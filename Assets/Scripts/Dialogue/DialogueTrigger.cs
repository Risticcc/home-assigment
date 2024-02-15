using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    private DialogueManager _dialogueManager;
    public bool startDialogue = false;
    void Start()
    {
        _dialogueManager = FindObjectOfType<DialogueManager>();
    }

    public void TriggerDialogue()
    {  
        _dialogueManager.StartDialogue(dialogue);
    }
    

    public void CloseConversationUI()
    {
        _dialogueManager.EndDialogue();
    }
}
