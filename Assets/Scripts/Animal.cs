using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{
    [Header("Animal Stats")]
    public string name_;
    [SerializeField] private float speed_;
    [SerializeField] public float jumpForce_;
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

        if (collision.CompareTag("OilWater"))
        {
            GameManager._Instance.setGameOver();
        }
        if (collision.CompareTag("Water") && name_ != "Penguin")
        {
            Debug.Log("touched Water");
            GameManager._Instance.setGameOver();
        }

        if (collision.CompareTag("LevelExit"))
        {
            GameManager._Instance.LevelExit();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("DeathZone"))
        {
            if (!(gameObject.name == "Arctic Fox(Clone)" || gameObject.name == "Arctic Fox" && gameObject.GetComponent<Sneaking>().stealthActive))
            {
                GameManager._Instance.setGameOver();
            }
        }

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






