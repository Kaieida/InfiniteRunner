using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactersController : MonoBehaviour
{
    [SerializeField] private float _movementSpeed = 10;
    [SerializeField] private float _jumpForce = 10;
    [SerializeField] private Animator _animator = null;
    [SerializeField] private Rigidbody _rigidBody = null;
    private bool _isGrounded;
    private bool _wasGrounded;
    private bool _jumpInput;
    void Update()
    {
        if (!_jumpInput && Input.GetKey(KeyCode.Space))
        {
            _jumpInput = true;
        }
        LaneChange();
    }
    private void FixedUpdate()
    {
        _animator.SetBool("Grounded", _isGrounded);
        transform.position += transform.forward * _movementSpeed * Time.deltaTime;
        _animator.SetFloat("MoveSpeed", _movementSpeed);
        JumpingAndLanding();
        _wasGrounded = _isGrounded;
        _jumpInput = false;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            _isGrounded = true;
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isGrounded = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isGrounded = false;
        }
    }
    private void JumpingAndLanding()
    {
        //bool jumpCooldownOver = (Time.time - jumpTimeStamp) >= minJumpInterval;

        /*if (jumpCooldownOver && _isGrounded && _jumpInput)
        {
             jumpTimeStamp = Time.time;
            _rigidBody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
        }*/
        if (_isGrounded && _jumpInput)
        {
            _rigidBody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
        }
        if (!_wasGrounded && _isGrounded)
        {
            _animator.SetTrigger("Land");
        }
        if (!_isGrounded && _wasGrounded)
        {
            _animator.SetTrigger("Jump");
        }
    }
    private void LaneChange()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            gameObject.transform.position += new Vector3(-10f,0.07f,0);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            gameObject.transform.position += new Vector3(10f, 0.07f, 0);
        }
    }
}
