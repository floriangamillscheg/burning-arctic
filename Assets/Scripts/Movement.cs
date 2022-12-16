using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour {

    private Transform groundCheck_;
    private float checkRadius_;
    private LayerMask whatIsGround_;


    private Rigidbody2D rigidbody_;

    // Sprite orientation
    private bool facingRight_ = true;
    
    //Jumping
    private bool isGrounded_ => Physics2D.OverlapCircle(groundCheck_.position, checkRadius_, whatIsGround_);

    // Start is called before the first frame update
    private void Start() {
        rigidbody_ = GetComponent<Rigidbody2D>();
        groundCheck_ = transform.Find("GroundChecker");
        if (groundCheck_ == null) {Debug.unityLogger.Log("ERROR!!! GroudChecker not found!!!");}
        checkRadius_ = 0.1f;
        whatIsGround_ = LayerMask.GetMask("Ground");
    }

    // Update is called once per frame
    private void Update() {
        // get the game object who is the current active animal
        GameObject animalGO = gameObject.GetComponent<SwitchAnimals>().GetCurrentAnimal();
        var (speed, jump) = animalGO.GetComponent<Animal>().GetMoveStats();

        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");
        if (isGrounded_ && inputY > 0) {
            rigidbody_.velocity = new Vector2(speed * inputX, 1 * jump);
        } else {
            rigidbody_.velocity = new Vector2(speed * inputX, rigidbody_.velocity.y);
        }
        if (animalGO.TryGetComponent(out Animator animator)) {
            animator.SetFloat("speed", Mathf.Abs(rigidbody_.velocity.x));
        }
        if (facingRight_ && inputX < 0) {Flip();} 
        else if (!facingRight_ && inputX > 0) {Flip();}


    }

    private void Flip() {
        facingRight_ = !facingRight_;
        transform.Rotate(0, 180, 0);
    }
}
