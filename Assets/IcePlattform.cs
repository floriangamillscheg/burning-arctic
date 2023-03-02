using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcePlattform : MonoBehaviour
{

    [SerializeField]
    private Animator cutSceneAnimator;
    private Collider2D collider;
    private SpriteRenderer spriteRenderer;
    private void Awake()
    {
        collider = GetComponent<Collider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Icicle"))
        {
            //gameObject.active = false;
            collider.isTrigger = true;
            spriteRenderer.enabled = false;
        }
       
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("IceBall"))
        {
            cutSceneAnimator.SetBool("cutScene4", true);

        }
    }
  
}
