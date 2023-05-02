using DG.Tweening;
using System.Drawing;
using UnityEngine;

public class Muv : MonoBehaviour
{
    
    public float xRotation = 60f;
    public float verticalInput;
  


    [SerializeField]
    private float rotationSpeed;

    [SerializeField]
    private Transform cameraTransform;
    [SerializeField] private Transform _groundChek;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] float _speed = 7f;
    public Bar Bar;
   
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

    private float JecpacBar = 30f;
    // Start is called before the first frame update
    void Start()
    {
        
        characterController = GetComponent<CharacterController>();
        originalStepOffset = characterController.stepOffset;
    }

    private bool isjec;
    private bool isFly;
    void Update()
    {
      
        isGraund = Physics.CheckSphere(_groundChek.position, groundDistanse, groundMask);
        if (Input.GetKey(KeyCode.Space))
        {
            isjec = true;
            isFly = true;
            Jecpac();
            
        }
        else
        {
            isFly = false;
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            isjec = true;
            JecpacDawn();
        }
        if (isGraund)
        {
            if (JecpacBar < 30)
            {
                JecpacBar += Time.deltaTime;
            }
            Bar.SetHealt(JecpacBar);
            


                isjec = false;

                if(isFly==false)
                {
                JecpacDawn();
                }
                PlayerRun();
                
            
        }
        else if(JecpacBar>0)
        {
            JecpacBar -= Time.deltaTime;
            Bar.SetHealt(JecpacBar);
            Fly();
            
        }
        if(JecpacBar <= 0)
        {
            JecpacDawn();
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
        animator.SetBool("Fly", true);
        animator.SetBool("IsMoving", false);
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

        

    private void PlayerRun()
    {


        animator.SetBool("Fly", false);
        

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
            animator.SetBool("IsMoving", true);

            
        }
        if (horizontal != 0f || vertical != 0f)
        {
            animator.SetBool("IsMoving", true);
        }


    }
    void OnDrawGizmosSelected()
    {
       
        //Gizmos.DrawWireSphere(_groundChek, groundDistanse);

    }


}
