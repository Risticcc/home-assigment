using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    [TextArea(3,20)]
    public string[] sentences;
    
    public bool expectInteraction = false;
    
}
