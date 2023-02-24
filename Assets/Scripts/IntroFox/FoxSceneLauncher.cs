using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoxSceneLauncher : MonoBehaviour
{


        [SerializeField] private GameObject script_;
        [SerializeField] private Sprite newSprite_;

    void OnCollisionEnter2D(Collision2D collision)
        {
            GameObject cage = GameObject.Find("Cage");
            gameObject.GetComponent<SpriteRenderer>().sprite = newSprite_;
            cage.GetComponent<BoxCollider2D>().enabled = false;
            script_.GetComponent<CageScene>().StartAnimation();
        }
}
