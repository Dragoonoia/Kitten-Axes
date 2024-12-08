using Fusion;
using UnityEngine;

public class PlayerAttack2 : NetworkBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] PlayerMovement moves;
    [SerializeField] private Transform attackTransformright;
    [SerializeField] private Transform attackTransformleft;
    [SerializeField] private Transform attackTransformup;
    [SerializeField] private Transform attackTransformdown;
    private bool Attacking = false;
    private float AttackTimer = 0;
    private bool AttackRight;
    private bool AttackLeft;
    private bool AttackUp;
    private bool AttackDown;
    void Start()
    {
        attackTransformright.gameObject.SetActive(false);
        attackTransformleft.gameObject.SetActive(false);
        attackTransformup.gameObject.SetActive(false);
        attackTransformdown.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (UserInput.instance.controls.Attack.AttackRight.WasPressedThisFrame() && !Attacking)
        {
            Debug.Log("abacate");
            if (!moves.Net_FlipX)
            {
                animator.SetTrigger("AttackFront");
            }
            else
            {
                animator.SetTrigger("AttackBack");
            }
                AttackTimer = 0.2f;
            Attacking = true;
            AttackRight = true;
            moves.NotKnock = true;
        }

        if (UserInput.instance.controls.Attack.AttackLeft.WasPressedThisFrame() && !Attacking)
        {
            Debug.Log("abacate");
            if (moves.Net_FlipX)
            {
                animator.SetTrigger("AttackFront");
            }
            else
            {
                animator.SetTrigger("AttackBack");
            }
            AttackTimer = 0.2f;
            Attacking = true;
            AttackLeft = true;
            moves.NotKnock = true;
        }

        if (UserInput.instance.controls.Attack.AttackUp.WasPressedThisFrame() && !Attacking)
        {
            Debug.Log("abacate");
            animator.SetTrigger("AttackUp");
            AttackTimer = 0.2f;
            Attacking = true;
            AttackUp = true;
            moves.NotKnock = true;
        }

        if (UserInput.instance.controls.Attack.AttackDown.WasPressedThisFrame() && !Attacking)
        {
            Debug.Log("abacate");
            animator.SetTrigger("AttackDown");
            AttackTimer = 0.2f;
            Attacking = true;
            AttackDown = true;
            moves.NotKnock = true;
        }




        if (Attacking)
        {
            if (AttackTimer < 0.1f && AttackTimer > 0)
            {
                if (AttackRight)
                {
                    attackTransformright.gameObject.SetActive(true);
                }
                if (AttackLeft)
                {
                    attackTransformleft.gameObject.SetActive(true);
                }
                if (AttackUp)
                {
                    attackTransformup.gameObject.SetActive(true);
                }
                if (AttackDown)
                {
                    attackTransformdown.gameObject.SetActive(true);
                }
            }
            AttackTimer -= Time.deltaTime;

            if (AttackTimer <= 0f)
            {
                attackTransformright.gameObject.SetActive(false);
                attackTransformleft.gameObject.SetActive(false);
                attackTransformup.gameObject.SetActive(false);
                attackTransformdown.gameObject.SetActive(false);
                AttackRight = false;
                AttackLeft = false;
                AttackUp = false;
                AttackDown = false;
                Attacking = false;
                moves.NotKnock = false;
            }
        }
        
    }


}
