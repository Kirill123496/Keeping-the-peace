using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class HaracterController : MonoBehaviour
{
    public float Speed = 10f;
    public float JumpForce = 300f;
    private bool _isGrounded;
    private Rigidbody2D _rb;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        MovementLogic();
        JumpLogic();
    }
    private void MovementLogic()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        Vector2 movement = new Vector2(moveHorizontal, 0.0f);
        _rb.AddForce(movement * Speed);
    }

    private void JumpLogic()
    {
        if (Input.GetAxis("Jump") > 0)
        {
            if (_isGrounded)
            {
                _rb.AddForce(Vector3.up * JumpForce);
            }
        }
    }

    private void AtackLogix()
    {
        
    }
    void OnCollisionEnter(Collision collision)
    {
        IsGroundedUpate(collision, true);
    }
    void OnCollisionExit(Collision collision)
    {
        IsGroundedUpate(collision, false);
    }
    private void IsGroundedUpate(Collision collision, bool value)
    {
        if (collision.gameObject.tag == ("Ground"))
        {
            _isGrounded = value;
        }
    }
}