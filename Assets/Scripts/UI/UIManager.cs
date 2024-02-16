using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject storePanel;
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private GameObject startPanel;
    [SerializeField] private GameObject playerPanel;
    [SerializeField] private GameObject inventoryPanel;
    
    public static UIManager Instance { get; private set; }
    
    public Action OnEquip;

    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        storePanel.SetActive(false);
        pausePanel.SetActive(false);
        dialoguePanel.SetActive(false);
        playerPanel.SetActive(false);
        startPanel.SetActive(true);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (pausePanel.activeSelf)
            {
                ClosePausePanel();
            }
            else
            {
                OpenPausePanel();
            }
        }
    }

    public void CloseStorePanel()
    {
        storePanel.SetActive(false);
    }

    public void CloseInventoryPanel()
    {
        inventoryPanel.SetActive(false);
    }

    public void OpenStorePanel()
    {
        CloseDialoguePanel();
        storePanel.SetActive(true);
    }
    
    public void ClosePausePanel()
    {
        pausePanel.SetActive(false);
    }
    
    public void OpenPausePanel()
    {
        CloseDialoguePanel();
        CloseStorePanel();
        pausePanel.SetActive(true);
    }
    
    public void CloseDialoguePanel()
    {
        dialoguePanel.SetActive(false);
    }

    public void RefreshPlayerPanel()
    {
        OnEquip?.Invoke();
    }

    public void StartGame()
    {
        startPanel.SetActive(false);
        playerPanel.SetActive(true);
        Time.timeScale = 1;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    
    
}
