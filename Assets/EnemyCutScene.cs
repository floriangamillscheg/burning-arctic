using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCutScene : MonoBehaviour
{
    private Animator enemyAnimator;
    private bool move = false;
    private float speed = 2.5f;
    [SerializeField]
    Transform target;
    // Start is called before the first frame update
    private void Awake()
    {
        enemyAnimator = GetComponent<Animator>();
    }


    private void Update()
    {
        if(move)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);
            if (Vector2.Distance(transform.position, target.position) < 1.5f)
            {
                Debug.Log("disance is smaller");
                enemyAnimator.SetBool("walk", false);
                move = false;

            }
        }
        

    }
    public void startAnimation()
    {

        enemyAnimator.SetBool("walk", true);
        move = true;
    }

}
