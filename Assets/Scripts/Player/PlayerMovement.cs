using System;
using System.Numerics;
using Unity.VisualScripting;
using UnityEditor.ShaderGraph;
using UnityEngine;
using UnityEngine.EventSystems;
using Vector3 = UnityEngine.Vector3;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] float _walkSpeed = 5f;
    [SerializeField] float _sprintSpeed = 7f;
    [SerializeField] float _drag = 5;
    private float _moveSpeed = 5f;

    [Header("Ground Check Parameters")]
    [SerializeField] LayerMask _isGround;
    [SerializeField] bool _grounded;
    private float _playerHeight = 2;

    [Header("References")]
    [SerializeField] Rigidbody _rb;

    private float _horizontalInput;
    private float _verticalInput;
    private Vector3 _moveDirection;

    private Animator animPlayer;
    private int ContadorReliquias;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.freezeRotation = true;
        animPlayer = GetComponent<Animator>();
    }

    void Update()
    {
        PlayerInputs();
        IsGrounded();
        SpeedControl();
    }

    void FixedUpdate()
    {
        Move();
    }

    private void PlayerInputs()
    {
        _horizontalInput = Input.GetAxis("Horizontal");
        _verticalInput = Input.GetAxis("Vertical");
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            _moveSpeed = _sprintSpeed;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            _moveSpeed = _walkSpeed;
        }
        //Para tomar la animacion Player -Cris- 
        animPlayer.SetFloat("Walkx", _horizontalInput);
        animPlayer.SetFloat("Walky", _verticalInput);
    }

    private void Move()
    {
        //calculo la direccion del movimiento y añado esa fuerza al RigidBody
        _moveDirection = transform.forward * _verticalInput + transform.right * _horizontalInput;

        _rb.AddForce(_moveDirection * _moveSpeed * 10f, ForceMode.Force);
    }

    //Determina si el jugador esta tocando el suelo y cambia el arrastre acorde a la situacion
    private void IsGrounded()
    {
        _grounded = Physics.Raycast(Vector3.up, Vector3.down, _playerHeight * 0.5f + 0.2f, _isGround);
        //Debug.DrawRay(Vector3.up, Vector3.down * (_playerHeight * 0.5f + 0.2f) ,Color.red,1f);

        if (_grounded)
        {
            _rb.linearDamping = _drag;
        }
        else
        {
            _rb.linearDamping = 0;
        }
    }

    private void SpeedControl()
    {
        //previente que el RigidBody supere el maximo de velocidad
        Vector3 flatVel = new Vector3(_rb.linearVelocity.x, 0f, _rb.linearVelocity.z);

        if (flatVel.magnitude > _moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * _moveSpeed;
            _rb.linearVelocity = new Vector3(limitedVel.x, _rb.linearVelocity.y, limitedVel.z);
        }
    }
}
