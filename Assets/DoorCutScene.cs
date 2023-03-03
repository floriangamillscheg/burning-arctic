using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorCutScene : MonoBehaviour
{

    public GameObject enemy;
    private Animator doorAnimator;
    private Collider2D collider;
    [SerializeField]
    private DialogueManager dialogueManager;

    [SerializeField]
    private Dialogue enemyDialogue;

    private void Awake()
    {
        doorAnimator = GetComponent<Animator>();
        collider = GetComponent<Collider2D>();

    }


    public void OpenDoor()
    {
        doorAnimator.SetTrigger("openDoor");
    }
    public void callEnemy()
    {
        Debug.Log("call Enemy");
        Debug.Log("call dialogue");
        collider.enabled = false;
        dialogueManager.currentDialogue = enemyDialogue;
        dialogueManager.StartDialogue(enemyDialogue);
        EnemyCutScene[] enemyCutScene = enemy.GetComponentsInChildren<EnemyCutScene>();
        foreach(EnemyCutScene cutscene in enemyCutScene)
            cutscene.GetComponent<EnemyCutScene>().startAnimation();

    }
}
