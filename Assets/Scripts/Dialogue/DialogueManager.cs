using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textBox;
    [SerializeField] private TextMeshProUGUI nameBox;
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private Animator animator;
    
    private Queue<string> _sentences;
    private ChoicesManager _choicesManager;
    
    //public Action DialogueOver;
    //public Action DialogueStart;
    void Start()
    {
        _choicesManager = GetComponent<ChoicesManager>();
        dialoguePanel.SetActive(false);
        
        _sentences = new Queue<string>();

    }
    
    public void StartDialogue(Dialogue dialogue, string npcName, bool useEvents)
    {
        //DialogueStart.Invoke();
        _sentences.Clear();
        
        if(useEvents)
            _choicesManager.ActivateChoices();
        
        dialoguePanel.SetActive(true);
        nameBox.text = npcName;
        
        foreach(var sentance in dialogue.sentences)
        {
            _sentences.Enqueue(sentance);
        }
        
        DisplayNextSentence();
    }
    

    private void DisplayNextSentence()
    {
        if (_sentences.Count == 0)
        {
            //EndDialogue(); because of buttons
            return;
        }

        var sentence = _sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }
    
    private IEnumerator TypeSentence(string sentence)
    { 
        textBox.text = "";
        foreach (var letter in sentence.ToCharArray())
        {
           textBox.text += letter;
            yield return null;
        }
    }
    
    public void EndDialogue()
    {
       // DialogueOver.Invoke();
        dialoguePanel.SetActive(false);
    }

  


}
