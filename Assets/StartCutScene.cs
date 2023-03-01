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
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Animal") && !alreadyPlayed)
        {
            currentCutScene = "cutScene" + cutSceneNumber.ToString();
            Debug.Log("start cutscene: " + currentCutScene);
            animator.SetBool(currentCutScene, true);
            
            Invoke(nameof(stopCutScene), 3.0f);
        }
    }

    private void stopCutScene()
    {
        animator.SetBool(currentCutScene, false);
        alreadyPlayed = true;

    }
}
