using Fusion;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : NetworkBehaviour
{
    cameraFollow cameracode;
    [Header("Movement")]
    [SerializeField] private float moveSpeed = 7f;
    [Header("Jumponthecadillac")]
    [SerializeField] private float jumpForce = 12f;
    [SerializeField] private float jumpTime = 0;
    [SerializeField] private bool isJumpin;

    [Header("Knock Knock")]
    [SerializeField] private float IGetKnockedDown = 0;
    [SerializeField] private float Yeet = 0;
    [SerializeField] private float FlyAwayNow = 0;

    [Header("IsThisRight?")]
    [SerializeField] public bool isFacingRight;
    [SerializeField] private GameObject sprite;

    [Header("ithrewitontheGROUND")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask whatIsGround;
    bool isGrounded;

    private Rigidbody2D body;
    private Collider2D collider;
    private SpriteRenderer spright;
    private float moveInput;
    
    private bool isFallin;
    private float jumptimeCounter;

    private RaycastHit2D groundhit;

    private bool Pare;

    Animator animator;

    private GameObject Player2;

    public override void Spawned()
    {
        if (HasStateAuthority)
        { 
        cameracode = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<cameraFollow>();
        cameracode.SetCameraTarget(transform);
        } 
    }

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        collider = GetComponent<Collider2D>();
        spright = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

        

        Pare = false;
    }

    private void Update()
    {
        
    }
    public override void FixedUpdateNetwork()
    {
        if (!Pare)
        {
            Move();
            Jump();
        }

        Knockback();

    }

    #region Movement Functions
    private void Move()
    {
        moveInput = UserInput.instance.moveInput.x;

        body.linearVelocity = new Vector2(moveInput * moveSpeed, body.linearVelocity.y);
        if (moveInput > 0 || moveInput < 0)
        {
            animator.SetBool("running", true);
            TurnCheck();
        }
        else if (moveInput == 0)
        {
            animator.SetBool("running", false);
        }

    }

    #endregion
    #region Jump Functions
    private void Jump()
    {
        isGrounded = Physics2D.OverlapCapsule(groundCheck.position, new Vector2(1.9f, 0.5f), CapsuleDirection2D.Horizontal, 0, whatIsGround);
        
        if (UserInput.instance.controls.Jumpin.Jumpin.WasPressedThisFrame() && isGrounded && !isJumpin)
        {
            animator.SetTrigger("Jump");
            isJumpin = true;
            jumpTime = 0.25f;
        }

        if (isJumpin && jumpTime > 0)
        {
            body.linearVelocity = new Vector2(body.linearVelocityX, jumpForce);
            jumpTime -= Time.deltaTime;
        }

        if (isJumpin && jumpTime <= 0)
        {
            isJumpin = false;
        }

        
    }

    #endregion
    #region turn functions
    private void TurnCheck()
    {
        if (UserInput.instance.moveInput.x > 0 && !isFacingRight)
        {
            Turn();

        }
        else if (UserInput.instance.moveInput.x < 0 && isFacingRight)
        {
            Turn();

        }
    }
    private void Turn()
    {
        if (isFacingRight)
        {

            spright.flipX = true;
            isFacingRight = false;
        }
        else
        {

            spright.flipX = false;
            isFacingRight = true;
        }
    }

    #endregion
    

    #region Knockback
    private void Knockback()
    {
        if (IGetKnockedDown > 0)
        {
            Pare = true;

            if (isFacingRight)
            {
                body.linearVelocity = new Vector2(moveSpeed * -1.5f, body.linearVelocity.y);
                IGetKnockedDown -= Time.deltaTime;
            }
            else
            {
                Turn();
                body.linearVelocity = new Vector2(moveSpeed * -1.5f, body.linearVelocity.y);
            }
        }
        else if (IGetKnockedDown <= 0 && Pare)
        {
            Pare = false;
        }

        if (Yeet > 0)
        {
            Pare = true;

            if (isFacingRight)
            {
                Turn();
                body.linearVelocity = new Vector2(moveSpeed * 1.5f, body.linearVelocity.y);
            }
            else
            {

                body.linearVelocity = new Vector2(moveSpeed * 1.5f, body.linearVelocity.y);
                Yeet -= Time.deltaTime;
            }
        }
        else if (Yeet <= 0 && Pare)
        {
            Pare = false;
        }

        if (FlyAwayNow > 0)
        {
            body.linearVelocity = new Vector2(body.linearVelocity.x, body.linearVelocityY + 2f);
            FlyAwayNow -= Time.deltaTime;
        }
    }
    public void ApplyKnockback()
    {
        IGetKnockedDown = 0.15f;
    }
    public void ApplyKnockfront()
    {
        Yeet = 0.10f;
    }
    public void ApplyKnockup()
    {
        FlyAwayNow = 0.20f;
    }
    #endregion
    #region Damaged

    private void OnTriggerEnter2D(UnityEngine.Collider2D collision)
    {
        if (collision.gameObject.tag == "MyEnemy")
        {
            
            ApplyKnockback();
        }
        if (collision.gameObject.tag == "DeathLine")
        {
            transform.position = new Vector2(16f, 6.5f);


        }
    }
  
    #endregion
}
