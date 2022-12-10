using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour
{
    //[Header("Movement")]
    //[SerializeField] private float speed_;
    private Rigidbody2D rigidbody_;

    // Sprite orientation
    private bool facingRight_ = true;
    
    //Jumping
    private bool isGrounded_ = true;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody_ = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
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

        if (facingRight_ && inputX < 0) {Flip();} 
        else if (!facingRight_ && inputX > 0) {Flip();}


    }

    private void Flip() {
        facingRight_ = !facingRight_;
        transform.Rotate(0, 180, 0);
    }
}
