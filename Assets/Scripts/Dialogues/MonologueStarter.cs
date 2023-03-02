using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonologueStarter : MonoBehaviour
{
 
    [SerializeField]
    private Dialogue dialogue;
    [SerializeField]
    private DialogueManager dialogueManager;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("StartDialogue");
        dialogueManager.currentDialogue = dialogue;
        dialogueManager.StartDialogue(dialogue);

    }
    
}

