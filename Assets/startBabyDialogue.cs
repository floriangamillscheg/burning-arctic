using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startBabyDialogue : MonoBehaviour
{

    [SerializeField]
    private DialogueManager dialogueManager;
    private Dialogue babyDialogue;
    [SerializeField]
    private Color color;

    [SerializeField]
    private Animator cutSceneAnimator;
        

    private int triggered = 0;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Animal"))
        {
            if (triggered == 0)
            {
                dialogueManager.currentDialogue = babyDialogue;
                Color color = new(0, 234, 253);
                dialogueManager.StartDialogue(babyDialogue);
                triggered++;
            }
            else if (triggered == 1)
            {
                cutSceneAnimator.SetBool("cutScene7", true);
                Invoke(nameof(goToEndScene), 4.0f);

            }

        }
    }

    private void goToEndScene()
    {
        GameManager._Instance.LevelExit();
    }
}
