using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New NPC", menuName = "NPC")]
public class NPC : ScriptableObject
{
     public string name;
     public Sprite image;
     public Dialogue dialogues;
     public string storeDescription;
}
