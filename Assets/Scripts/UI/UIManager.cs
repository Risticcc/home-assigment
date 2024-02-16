using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject storePanel;
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject dialoguePanel;


    private void Start()
    {
        storePanel.SetActive(false);
        pausePanel.SetActive(false);
        dialoguePanel.SetActive(false);
    }

    public void CloseStorePanel()
    {
        storePanel.SetActive(false);
    }
    
    public void OpenStorePanel()
    {
        storePanel.SetActive(true);
    }
    
    public void ClosePausePanel()
    {
        pausePanel.SetActive(false);
    }
    
    public void OpenPausePanel()
    {
        pausePanel.SetActive(true);
    }
    
    public void CloseDialoguePanel()
    {
        dialoguePanel.SetActive(false);
    }
}
