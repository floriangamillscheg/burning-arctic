using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]
public class Animal : MonoBehaviour
{
    [Header("Player Movement")]
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private int extraJumps;

    public int health = 100;

    [Header("Ground Check")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float checkRadius;
    [SerializeField] private LayerMask whatIsGround;




    public Animator animator;



    private int _count;
    public Rigidbody2D _rigidbody;

    private bool _facingRight = true;
    private int _extraJumpValue;

    private bool IsGrounded => Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _extraJumpValue = extraJumps;
    }

    private void Update()
    {

        var moveInput = Input.GetAxis("Horizontal");
        //        Debug.Log(moveInput);

        _rigidbody.velocity = new Vector2(moveInput * speed, _rigidbody.velocity.y);
        animator.SetFloat("speed", Mathf.Abs(moveInput * speed));

        if (!_facingRight && moveInput > 0)
            Flip();
        else if (_facingRight && moveInput < 0)
            Flip();

        if (IsGrounded)
        {
            _extraJumpValue = extraJumps;
        }

        if (Input.GetButtonDown("Jump"))
            Debug.Log("JumP!");

        if (Input.GetButtonDown("Jump") &&
            (IsGrounded || _extraJumpValue-- > 0))
        {
            _rigidbody.velocity = Vector2.up * jumpForce;
        }

    }

    private void Flip()
    {
        _facingRight = !_facingRight;

        transform.Rotate(0f, 180f, 0f);
    }
}




