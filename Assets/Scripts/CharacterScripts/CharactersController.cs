using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactersController : MonoBehaviour
{
    [SerializeField] private float _movementSpeed = 10;
    [SerializeField] private float _jumpForce = 10;
    [SerializeField] private Animator _animator = null;
    [SerializeField] private Rigidbody _rigidBody = null;
    public bool _isGrounded;
    private bool _wasGrounded;
    private bool _jumpInput;
    void Update()
    {
        if (!GameOver.Instance.IsGameOver)
        {
            if (!_jumpInput && Input.GetKeyDown("space"))
            {
                _jumpInput = true;
            }
            _movementSpeed += Time.deltaTime * 1000;
            _animator.SetBool("Grounded", _isGrounded);
            _rigidBody.AddForce(transform.forward * _movementSpeed * Time.deltaTime);
            JumpingAndLanding();
            _wasGrounded = _isGrounded;
            _jumpInput = false;
            LaneChange();
        }
        else if(GameOver.Instance.IsGameOver)
        {
            _movementSpeed = 0;
            _animator.SetBool("IsGameOver", true);
            Debug.Log("GameOver");
        }
        transform.rotation = Quaternion.Euler(0, 0, 0);
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
        /*if (!_wasGrounded && _isGrounded)
        {
            _animator.SetTrigger("Land");
        }
        if (!_isGrounded && _wasGrounded)
        {
            _animator.SetTrigger("Jump");
        }*/
    }
    private void LaneChange()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            _rigidBody.MovePosition(gameObject.transform.position + new Vector3(-10, 0, 0));
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            _rigidBody.MovePosition(gameObject.transform.position + new Vector3(10, 0, 0));
        }
    }
}
