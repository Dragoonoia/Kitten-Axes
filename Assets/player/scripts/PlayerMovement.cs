using Fusion;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : NetworkBehaviour, iDamage
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
    [Networked, OnChangedRender(nameof(METODOQUEUSAOFLIPX))] public bool Net_FlipX { get; set; }
    [SerializeField] private SpriteRenderer spritey;

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
        spritey = GetComponent<SpriteRenderer>();
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
        if (UserInput.instance.moveInput.x > 0 && Net_FlipX)
        {
            Net_FlipX = false;

        }
        else if (UserInput.instance.moveInput.x < 0 && !Net_FlipX)
        {
            Net_FlipX = true;

        }
    }

    public void METODOQUEUSAOFLIPX()
    {
        spritey.flipX = Net_FlipX;
    }

    #endregion
    #region Knockback
    private void Knockback()
    {
        if (IGetKnockedDown > 0 || Yeet > 0 || FlyAwayNow > 0)
        {
            if (IGetKnockedDown > 0)
            {
                Pare = true;

                if (Net_FlipX)
                {
                    body.linearVelocity = new Vector2(moveSpeed * -1.5f, body.linearVelocity.y);
                    IGetKnockedDown -= Time.deltaTime;
                }
                else
                {
                    Net_FlipX = true;
                    body.linearVelocity = new Vector2(moveSpeed * -1.5f, body.linearVelocity.y);
                }
            }


            if (Yeet > 0)
            {
                Pare = true;

                if (!Net_FlipX)
                {
                    
                    body.linearVelocity = new Vector2(moveSpeed * 1.5f, body.linearVelocity.y);
                    Yeet -= Time.deltaTime;
                }
                else
                {
                    Net_FlipX = false;
                    body.linearVelocity = new Vector2(moveSpeed * 1.5f, body.linearVelocity.y);
                    
                }
            }

            if (FlyAwayNow > 0)
            {
                body.linearVelocity = new Vector2(body.linearVelocity.x, 2f);
                FlyAwayNow -= Time.deltaTime;
            }
        }
        if (Yeet <= 0 && Pare)
        {
            Pare = false;
        }
        if (IGetKnockedDown <= 0 && Pare)
        {
            Pare = false;
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

    public void damage(float damageAmmount)
    {
        ApplyKnockback();
    }

    #endregion
}
