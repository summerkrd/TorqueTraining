using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private Transform _cameraCenter;

    [SerializeField] private float _torqueForce = 1f;
    [SerializeField] private float _jumpForce = 1f;

    private string _verticalAxis = "Vertical";
    private string _horizontalAxis = "Horizontal";

    private float _yInput;
    private float _xInput;

    private float _groundDrag = 1f;
    private float _jumpDrag = 0f;
    private float _groundAngularDrag = 0.5f;
    private float _jumpAngularDrag = 5f;

    private bool _isGrounded;    

    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _xInput = Input.GetAxis(_horizontalAxis);
        _yInput = Input.GetAxis(_verticalAxis);

        Jump();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void OnCollisionStay(Collision collision)
    {        
        CollisionHandling(true, _groundDrag, _groundAngularDrag);        
    }

    private void OnCollisionExit(Collision collision)
    {
        CollisionHandling(false, _jumpDrag, _jumpAngularDrag);        
    }

    private void Jump()
    {
        if (_isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
            }
        }
    }

    private void Move()
    {
        _rigidbody.AddTorque(_cameraCenter.right * _yInput * _torqueForce);
        _rigidbody.AddTorque(-_cameraCenter.forward * _xInput * _torqueForce);
    }

    private void CollisionHandling(bool isGrounded, float drag, float angularDrag)
    {
        _isGrounded = isGrounded;
        _rigidbody.drag = drag;
        _rigidbody.angularDrag = angularDrag;
    }
}
