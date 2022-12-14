using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour {

    [Header("Animal Stats")]
    [SerializeField] private float speed_;
    [SerializeField] private float jumpForce_;
    //[SerializeField] private int extraJumps_; //useless
    [SerializeField] int health_;
    [SerializeField] int weight_;

	
    public Animator animator;

    public (float, float) GetMoveStats() {
        return (speed_, jumpForce_);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        Debug.Log("OnTriggerEntter");
        if(collision.CompareTag("Water")) {
            GameManager._Instance.setGameOver();
        }

        if(collision.CompareTag("Obstacle") && Input.GetKey(KeyCode.F)) {
            collision.attachedRigidbody.AddForce(Vector3.up * jumpForce_);
            Debug.Log("Trigger Entered");

        }
    }
}






