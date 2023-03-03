using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XYMovement : MonoBehaviour
{
    Rigidbody2D body;

    float horizontal;
    float vertical;

    public float swimSpeed;

    private bool facingRight_ = true;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        GameObject animalGO = gameObject.GetComponent<SwitchAnimals>().GetCurrentAnimal();
        var (speed, _, _) = animalGO.GetComponent<Animal>().GetMoveStats();

        swimSpeed = speed;

        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        if (animalGO.TryGetComponent(out Animator animator))
        {
            animator.SetFloat("speed", Mathf.Abs(body.velocity.x));
        }
        if (facingRight_ && horizontal < 0) { Flip(); }
        else if (!facingRight_ && horizontal > 0) { Flip(); }

    }

    private void FixedUpdate()
    {
        body.velocity = new Vector2(horizontal * swimSpeed, vertical * swimSpeed);
    }

    private void Flip()
    {
        facingRight_ = !facingRight_;
        transform.Rotate(0, 180, 0);
    }
}
