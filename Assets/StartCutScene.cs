using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCutScene : MonoBehaviour
{
    public Animator animator;
    [SerializeField]
    private int cutSceneNumber;
    private string currentCutScene;
    private bool alreadyPlayed = false;
    [SerializeField]
    private bool backToMainCamera = true;

    [SerializeField]
    private Dialogue dialogue = null;
    [SerializeField]
    private DialogueManager dialogueManager = null;

    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Animal") && !alreadyPlayed)
        {
            currentCutScene = "cutScene" + cutSceneNumber.ToString();
            Debug.Log("start cutscene: " + currentCutScene);
            animator.SetBool(currentCutScene, true);

            if(backToMainCamera)
                Invoke(nameof(stopCutScene), 3.0f);

            if(dialogue != null && dialogueManager != null)
            {
                Invoke(nameof(startDialogue), 1.5f);
            }
                
        }
    }

    private void startDialogue()
    {
        dialogueManager.currentDialogue = dialogue;
        dialogueManager.StartDialogue(dialogue);

    }

    private void stopCutScene()
    {
        animator.SetBool(currentCutScene, false);
        alreadyPlayed = true;

    }
}
