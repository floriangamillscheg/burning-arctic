using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerIcicle : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject animatedIcicle;
    public Animator icicleAnimator;
    public Animator cutSceneAnimator;
    public GameObject icicleParent;
    public Collider2D icePlattform;
    const string cutScene = "cutScene3";
    private bool cutScenePlayed;
    private int counter = 0;
    private Collider2D collider;

    private void Awake()
    {
        collider = GetComponent<Collider2D>();
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("collision: " + collision.collider.gameObject.name);

        if(collision.collider.gameObject.name == "Bear" )//&& !alreadyPlayed)
        {
            string currentCutScene = "cutScene3";
            Debug.Log("start cutscene: " + currentCutScene);
            cutSceneAnimator.SetBool(currentCutScene, true);

            Invoke(nameof(stopCutScene), 3.0f);
            icicleAnimator.SetTrigger("startShaking");
            counter++;
        }
        if(counter == 3)
        {
            animatedIcicle.GetComponent<Animator>().enabled = false;
            foreach (Rigidbody2D body in icicleParent.GetComponentsInChildren<Rigidbody2D>())
                body.simulated = true;
            collider.enabled = false;
            icePlattform.isTrigger = true;
        }
        Debug.Log("counter: " + counter);

    }

    private void stopCutScene()
    {
        cutSceneAnimator.SetBool(cutScene, false);
        //cutScenePlayed = true;

    }
}
