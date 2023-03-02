using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour {
    
    // Layers
    private LayerMask whatIsGround_;
    private LayerMask whatIsWater_;

    // body
    private Rigidbody2D rigidbody_;

    // Sprite orientation
    private bool facingRight_ = true;

    //Jumping
    private bool isGrounded_ => GetComponent<SwitchAnimals>().GetCurrentAnimal().GetComponent<CapsuleCollider2D>().IsTouchingLayers(whatIsGround_);
    private bool isOnWater_ => GetComponent<SwitchAnimals>().GetCurrentAnimal().GetComponent<CapsuleCollider2D>().IsTouchingLayers(whatIsWater_);

    // Start is called before the first frame update
    private void Start() {
        rigidbody_ = GetComponent<Rigidbody2D>();
        whatIsGround_ = LayerMask.GetMask("Ground");
        whatIsWater_ = LayerMask.GetMask("Water");
    }

    // Update is called once per frame
    private void Update() {
        // get the game object who is the current active animal
        GameObject animalGO = gameObject.GetComponent<SwitchAnimals>().GetCurrentAnimal();
        Animal animal = animalGO.GetComponent<Animal>();
        var (speed, jumpforce, jumpsleft) = animal.GetMoveStats();
        rigidbody_.mass = animal.getMass();

        float inputX = Input.GetAxis("Horizontal");

        if (isGrounded_ && (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow))) {
            rigidbody_.velocity = new Vector2(speed * inputX, jumpforce);
        } else if (!isOnWater_ && jumpsleft > 0 && (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow))) {
            rigidbody_.velocity = new Vector2(speed * inputX, jumpforce);
            animal.UseExtraJump();
        } else if (isOnWater_ && (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow))) {
            rigidbody_.velocity = new Vector2(speed * inputX, speed);
        } else if (isOnWater_ && Input.GetKeyDown(KeyCode.DownArrow)) {
            rigidbody_.velocity = new Vector2(speed * inputX, -speed);
        } else {
            rigidbody_.velocity = new Vector2(speed * inputX, rigidbody_.velocity.y);
        }

        if (isGrounded_) {animal.ResetJumps();}

        if (animalGO.TryGetComponent(out Animator animator))
        {
            animator.SetFloat("speed", Mathf.Abs(rigidbody_.velocity.x));
        }

        if (facingRight_ && inputX < 0) { Flip(); }
        else if (!facingRight_ && inputX > 0) { Flip(); }


    }

    private void Flip() {
        facingRight_ = !facingRight_;
        transform.Rotate(0, 180, 0);
    }

    public bool GetGroundedStatus() {
        return isGrounded_;
    }

}
