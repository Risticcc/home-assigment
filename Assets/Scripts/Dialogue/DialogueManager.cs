using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textBox;
    [SerializeField] private TextMeshProUGUI nameBox;
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private Animator animator;
    
    private Queue<string> _sentences;
    
    //public Action DialogueOver;
    //public Action DialogueStart;
    void Start()
    {
        _sentences = new Queue<string>();
        dialoguePanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartDialogue(Dialogue dialogue)
    {
        //DialogueStart.Invoke();
        _sentences.Clear();
        
        dialoguePanel.SetActive(true);
        nameBox.text = dialogue.name;
        
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
            EndDialogue();
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
