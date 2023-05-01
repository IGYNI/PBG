using DG.Tweening;
using System.Drawing;
using UnityEngine;

public class Muv : MonoBehaviour
{
    public bool isUp;
    public float xRotation = 60f;
    public float verticalInput;
  


    [SerializeField]
    private float rotationSpeed;

    [SerializeField]
    private Transform cameraTransform;
    [SerializeField] private Transform _groundChek;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] float _speed = 7f;
    private float _turntime = 0.1f;
    private float turn;
    private float gravity = 1;
    public Vector3 velocity;
    private bool isGraund;
    private float groundDistanse = 0.4f;

    public Animator animator;
    private CharacterController characterController;
    private float ySpeed;
    private float originalStepOffset;
    private float? lastGroundedTime;
  

    // Start is called before the first frame update
    void Start()
    {
        isUp = true;
        characterController = GetComponent<CharacterController>();
        originalStepOffset = characterController.stepOffset;
    }

    private bool isjec;
    void Update()
    {
        isGraund = Physics.CheckSphere(_groundChek.position, groundDistanse, groundMask);
        if (Input.GetKey(KeyCode.Space))
        {
            isjec = true;
            Jecpac();
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            isjec = true;
            JecpacDawn();
        }
        if (isGraund)
        {
            if (PlayerState.Instance.CurrentState == PlayerStates.PickedUpItem == false)
            {
                isjec = false;
                PlayerRun();
            }
        }
        else
        {
            Fly();
        }
    }
    
    private void Jecpac()
    {
        animator.SetBool("IsMoving", false);
        
       
           //Grav
             velocity.y = -2f;

        velocity.y -= gravity * Time.deltaTime;
       characterController.Move(-velocity * Time.deltaTime);

        
    }
    private void JecpacDawn()
    {
        animator.SetBool("IsMoving", false);


        //Grav
        velocity.y = 2f;

        velocity.y -= gravity * Time.deltaTime;
        characterController.Move(-velocity * Time.deltaTime);

        
    }

    private void Fly()
    {
        float horizontal = Input.GetAxisRaw("Horizontal") * Time.deltaTime;
        float vertical = Input.GetAxisRaw("Vertical") * Time.deltaTime;
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= .1f)
        {
            float targetAgle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cameraTransform.transform.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAgle, ref turn, _turntime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            Vector3 moveDirecton = Quaternion.Euler(0f, targetAgle, 0f) * Vector3.forward;
            characterController.Move(_speed * Time.deltaTime * moveDirecton.normalized);


        }
    }


    private void OnAnimatorMove()
    {
        Vector3 velocity = animator.deltaPosition;

        if (isUp == true&& isjec == false&& !isGraund)
        {
            velocity.y = ySpeed * Time.deltaTime; 
        }
        characterController.Move(velocity);
    }

   


    private void PlayerRun()
    {
        
       
       

        
        float horizontalInput = Input.GetAxis("Horizontal")*Time.deltaTime;
        float verticalInput = Input.GetAxis("Vertical")*Time.deltaTime;

        Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput).normalized;
        
        movementDirection = Quaternion.AngleAxis(cameraTransform.rotation.eulerAngles.y, Vector3.up) * movementDirection;
        movementDirection.Normalize();

        ySpeed += Physics.gravity.y * Time.deltaTime;

        if (characterController.isGrounded)
        {
            lastGroundedTime = Time.time;
        }
        characterController.stepOffset = 0;
        

        if (movementDirection != Vector3.zero)
        {
            animator.SetBool("IsMoving", true);

            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
        else
        {
            animator.SetBool("IsMoving", false);
        }
    }
    void OnDrawGizmosSelected()
    {
       
        //Gizmos.DrawWireSphere(_groundChek, groundDistanse);

    }


}
