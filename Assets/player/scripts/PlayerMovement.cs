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
    [SerializeField] private float jumpTime = 0.5f;

    [SerializeField] public bool isFacingRight;
    [SerializeField] private GameObject sprite;

    [Header("ithrewitontheGROUND")]
    [SerializeField] private float extraheight = 0.25f;
    [SerializeField] private LayerMask whatIsGround;

    private Rigidbody2D body;
    private Collider2D collider;
    private float moveInput;


    private bool isJumpin;
    private bool isFallin;
    private float jumptimeCounter;

    private RaycastHit2D groundhit;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        collider = GetComponent<Collider2D>();

        cameracode = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<cameraFollow>();
        //cameracode.SetCameraTarget();
    }

    private void Update()
    {
        Move();
        Jump();
    }
    public override void FixedUpdateNetwork()
    {

        

    }

    #region Movement Functions
    private void Move()
    {
        moveInput = UserInput.instance.moveInput.x;

        body.linearVelocity = new Vector2(moveInput * moveSpeed, body.linearVelocity.y);
        if (moveInput > 0 || moveInput < 0)
        {
            TurnCheck();
        }

    }

    #endregion
    #region Jump Functions
    private void Jump()
    {
        if (UserInput.instance.controls.Jumpin.Jumpin.WasPressedThisFrame() && isGrounded())
        {
            //pushed :D
            isJumpin = true;
            jumptimeCounter = jumpTime;
            body.linearVelocity = new Vector2(body.linearVelocityX, jumpForce);
        }

        if (UserInput.instance.controls.Jumpin.Jumpin.IsPressed())
        {
            if (jumptimeCounter > 0 && isJumpin)
            {
                body.linearVelocity = new Vector2(body.linearVelocityX, jumpForce);
                jumptimeCounter -= Time.deltaTime;
            }

            else
            {
                isJumpin = false;
            }

        }
        if (UserInput.instance.controls.Jumpin.Jumpin.WasReleasedThisFrame())
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
            rotationCheck();
            isFacingRight = false;
        }
        else
        {
            rotationCheck();
            isFacingRight = true;
        }
    }

    private void rotationCheck()
    {
        if (isFacingRight)
        {
            Vector3 rotator = new Vector3(transform.position.x, 0f, transform.position.z);
            transform.rotation = Quaternion.Euler(rotator);
        }
        else
        {
            Vector3 rotator = new Vector3(transform.position.x, 180f, transform.position.z);
            transform.rotation = Quaternion.Euler(rotator);
        }
    }
    #endregion
    #region Ground Check
    private bool isGrounded()
    {
        groundhit = Physics2D.BoxCast(collider.bounds.center, collider.bounds.size, 0f, Vector2.down, extraheight, whatIsGround);

        if (groundhit.collider != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    #endregion

}
