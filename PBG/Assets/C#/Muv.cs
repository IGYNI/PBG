using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Muv : MonoBehaviour
{
    [SerializeField] private CharacterController _controller;
    [SerializeField] private Transform _groundChek;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] float _speed = 7f;

    //public Animator animator;

    private float _turntime = 0.1f;
    private float turn;
    public float gravity = -1;
    private Vector3 velocity;
    private bool isGraund;
    private float groundDistanse = 0.4f;


    void Update()
    {
        PlayerRun();
    }
    private void PlayerRun()
    {
        isGraund = Physics.CheckSphere(_groundChek.position, groundDistanse, groundMask);

        if (isGraund && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float _horizontal = Input.GetAxisRaw("Horizontal") * Time.deltaTime;
        float _vertical = Input.GetAxisRaw("Vertical") * Time.deltaTime;
        Vector3 _direction = new Vector3(_vertical, 0f, -_horizontal).normalized;
        velocity.y += gravity * Time.deltaTime;
        _controller.Move(velocity * Time.deltaTime);
        if (_groundChek.position.y < -1f)
        {
           // FindObjectOfType<GameOver>().EndGame();
        }

        if (_direction.magnitude >= .1f)
        {
            float targetAgle = Mathf.Atan2(_direction.x, _direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAgle, ref turn, _turntime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            _controller.Move(_direction * _speed * Time.deltaTime);


           // animator.SetBool("go", true);
        }
       // else
      //  {animator.SetBool(, false); }

    }



}
