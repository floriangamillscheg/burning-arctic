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

    public (float, float) GetMoveStats() {
        return (speed_, jumpForce_);
    }
}
