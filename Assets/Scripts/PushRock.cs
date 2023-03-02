using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushRock : MonoBehaviour {
    private Rigidbody2D rigidbody_;

    private void Start() {
        rigidbody_ = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Player") {
            rigidbody_.constraints |= RigidbodyConstraints2D.FreezePositionX;
            if (collision.gameObject.GetComponent<SwitchAnimals>().GetCurrentAnimal().GetComponent<Animal>().name_ == "Bear") {
                rigidbody_.constraints ^= RigidbodyConstraints2D.FreezePositionX; //RigidbodyConstraints2D.None;
            }
        }
    }

}