using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{
    [Header("Animal Stats")]
    public string name_;
    [SerializeField] private float speed_;
    [SerializeField] private float jumpForce_;
    //[SerializeField] private int extraJumps_; //useless
    [SerializeField] int health_;
    [SerializeField] int weight_;
    [SerializeField] int mass_;

    public (float, float) GetMoveStats()
    {
        return (speed_, jumpForce_);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Water") && name_ != "Penguin")
        {
            GameManager._Instance.setGameOver();
        }

        /* What does it does ? What is it's purpose ?
        if(collision.CompareTag("Obstacle") && Input.GetKey(KeyCode.F)) {
            collision.attachedRigidbody.AddForce(Vector3.up * jumpForce_);
            Debug.Log("Trigger Entered");

        }
        */
    }

    public int getMass()
    {
        return mass_;
    }
    public string getName()
    {
        return name_;
    }

    enum ANIMALTYPE
    {
        BEAR,

    }
}






