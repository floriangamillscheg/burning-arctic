using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCutScene : MonoBehaviour
{
    public Animator animator;
    [SerializeField]
    private int cutSceneNumber;
    private string currentCutScene;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Animal"))
        {
            currentCutScene = "cutScene" + cutSceneNumber.ToString();
            Debug.Log("start cutscene: " + currentCutScene);
            animator.SetBool(currentCutScene, true);
            if (animator == null)
                Debug.Log("animator is null");
            Invoke(nameof(stopCutScene), 3.0f);
        }
    }

    private void stopCutScene()
    {
        animator.SetBool(currentCutScene, false);
        Destroy(gameObject);

    }
}
