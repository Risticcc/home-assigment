using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseInteract : MonoBehaviour
{
    private GameObject InteractionPanel { get; set; }
    public bool PromptShown = false;
    private float _timeToHide = 2f;

    public abstract void Interact(GameObject gameObject);

   
    protected virtual void ShowInteractionPanel()
    {
        InteractionPanel.SetActive(true);
        PromptShown = true;
    }

    protected virtual void HideInteractionPanel()
    {
        Debug.Log("E pressed, hiding panel");
        InteractionPanel.SetActive(false);
    }

    protected virtual void Init(GameObject interactionPanel)
    {
        InteractionPanel = interactionPanel;
        HideInteractionPanel();
    }
    

}
