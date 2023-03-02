using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour {

    //private Transform groundCheck_;
    //private float checkRadius_;
    private LayerMask whatIsGround_;
    private LayerMask whatIsWater_;


    private Rigidbody2D rigidbody_;


    // Sprite orientation
    private bool facingRight_ = true;

    //Jumping
    private bool isGrounded_ => GetComponent<SwitchAnimals>().GetCurrentAnimal().GetComponent<CapsuleCollider2D>().IsTouchingLayers(whatIsGround_);
    private bool isOnWater_ => GetComponent<SwitchAnimals>().GetCurrentAnimal().GetComponent<CapsuleCollider2D>().IsTouchingLayers(whatIsWater_);
    public bool doubleJumpEnabled;
    private bool canDoubleJump;

    // Start is called before the first frame update
    private void Start()
    {
        rigidbody_ = GetComponent<Rigidbody2D>();
        /*groundCheck_ = transform.Find("GroundChecker");
        if (groundCheck_ == null) { Debug.unityLogger.Log("ERROR!!! GroudChecker not found!!!"); }
        checkRadius_ = 0.4f;*/
        whatIsGround_ = LayerMask.GetMask("Ground");
        whatIsWater_ = LayerMask.GetMask("Water");

    }

    // Update is called once per frame
    private void Update()
    {
        // get the game object who is the current active animal
        GameObject animalGO = gameObject.GetComponent<SwitchAnimals>().GetCurrentAnimal();
        Animal animal = animalGO.GetComponent<Animal>();
        var (speed, jump) = animal.GetMoveStats();
        rigidbody_.mass = animal.getMass();

        float inputX = Input.GetAxis("Horizontal");
        //float inputY = Input.GetAxis("Vertical");

        Debug.Log("isGrounded " + isGrounded_);
        Debug.Log("isOnWater_ " + isOnWater_);

        if ((/*animal.getName() == "Penguin" ||*/ isGrounded_) && (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow)))
        {
            rigidbody_.velocity = new Vector2(speed * inputX, 1 * jump);
        }
        else if (!isGrounded_ && doubleJumpEnabled && canDoubleJump && (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow)))
        {
            canDoubleJump = false;
            rigidbody_.velocity = new Vector2(speed * inputX, 1 * jump);
        }
        else
        {
            rigidbody_.velocity = new Vector2(speed * inputX, rigidbody_.velocity.y);
        }

        if (isGrounded_ && !canDoubleJump && doubleJumpEnabled)
        {
            canDoubleJump = true;
        }

        if (animalGO.TryGetComponent(out Animator animator))
        {
            animator.SetFloat("speed", Mathf.Abs(rigidbody_.velocity.x));
        }

        if (facingRight_ && inputX < 0) { Flip(); }
        else if (!facingRight_ && inputX > 0) { Flip(); }


    }

    private void Flip()
    {
        facingRight_ = !facingRight_;
        transform.Rotate(0, 180, 0);
    }

    public bool GetGroundedStatus()
    {
        return isGrounded_;
    }

}
