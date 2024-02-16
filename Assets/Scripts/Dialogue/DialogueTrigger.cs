using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] private NPC npc;
    private DialogueManager _dialogueManager;
    void Start()
    {
        _dialogueManager = FindObjectOfType<DialogueManager>();
    }

    public void TriggerDialogue()
    {  
        _dialogueManager.StartDialogue(npc.dialogues, npc.name);
    }
    

    public void CloseConversationUI()
    {
        _dialogueManager.EndDialogue();
    }
}
