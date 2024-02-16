using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoicesManager : MonoBehaviour
{
    [SerializeField] private GameObject[] choices;
    
    private void Start()
    {
        DeactivateChoices();
    }
    
    public void ActivateChoices()
    {
        foreach (var button in choices)
        {
            button.SetActive(true);
        }
    }

    public void DeactivateChoices()
    {
        foreach (var button in choices)
        {
            button.SetActive(false);
        }
    }
    
    public void ClosingChoice()
    {
        UIManager.Instance.CloseDialoguePanel();
    }
    
    public void OpenStore() //TODO
    {
        UIManager.Instance.OpenStorePanel();
    }
}
