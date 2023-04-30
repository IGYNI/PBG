using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    private float gravity = -1;
    private Vector3 velocity;
    private bool isGraund;
    private float groundDistanse = 0.4f;
    private Camera _camera;

    public bool isUp;
    private void Start()
    {
        isUp = true;
        _camera = Camera.main;
    }

    void Update()
    {
        if (isUp==true)
        {
            if (PlayerState.Instance.CurrentState == PlayerStates.PickedUpItem == false)
                PlayerRun();
        }
        else
        {
            UpTuLaad();
        }

    }

    private void UpTuLaad()
    {
        
        float verticalInput = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(0f, verticalInput, 0f).normalized * speed * Time.deltaTime;

        Vector3 targetPosition = transform.position + movement;

        // ограничиваем перемещение объекта в пределах границ BoxCollider
        if (movementBounds.bounds.Contains(targetPosition))
        {
            transform.position = targetPosition;
        }
    }
    public float speed = 5f;
    public BoxCollider movementBounds;






    private void PlayerRun()
    {
        isGraund = Physics.CheckSphere(_groundChek.position, groundDistanse, groundMask);

        if (isGraund && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float horizontal = Input.GetAxisRaw("Horizontal") * Time.deltaTime;
        float vertical = Input.GetAxisRaw("Vertical") * Time.deltaTime;
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
        velocity.y += gravity * Time.deltaTime;
        _controller.Move(velocity * Time.deltaTime);
        if (_groundChek.position.y < -1f)
        {
           // FindObjectOfType<GameOver>().EndGame();
        }

        if (direction.magnitude >= .1f)
        {
            float targetAgle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + _camera.transform.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAgle, ref turn, _turntime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            Vector3 moveDirecton = Quaternion.Euler(0f, targetAgle, 0f) * Vector3.forward;
            _controller.Move(_speed * Time.deltaTime * moveDirecton.normalized);


           // animator.SetBool("go", true);
        }
       // else
      //  {animator.SetBool(, false); }

    }



}
