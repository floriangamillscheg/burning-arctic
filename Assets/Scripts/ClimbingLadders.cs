using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbingLadders : MonoBehaviour
{

    bool canClimb = false;
    float speed = 2;
    private float oldJumpForce;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            oldJumpForce = gameObject.GetComponent<Animal>().jumpForce_;
            gameObject.GetComponent<Animal>().jumpForce_ = 0;
            canClimb = true;
            GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>().gravityScale = 0;

        }
    }
    

        private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            gameObject.GetComponent<Animal>().jumpForce_ = oldJumpForce;
            canClimb = false;
            GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>().gravityScale = 1;
        }
    }

    void Update()
    {
        if (canClimb)
        {
            if (Input.GetKey(KeyCode.W))
            {
                GameObject.FindWithTag("Player").transform.Translate(new Vector3(0, 1, 0) * Time.deltaTime * speed);
            }
            if (Input.GetKey(KeyCode.S))
            {
                GameObject.FindWithTag("Player").transform.Translate(new Vector3(0, -1, 0) * Time.deltaTime * speed);
            }
        }
    }
}
