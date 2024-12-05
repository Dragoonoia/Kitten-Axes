using UnityEngine;
using Fusion;

public class PlayerAttack : NetworkBehaviour
{
    private RaycastHit2D[] hits;
    [SerializeField] private Transform attackTransformup;
    [SerializeField] private Transform attackTransformdown;
    [SerializeField] private Transform attackTransformleft;
    [SerializeField] private Transform attackTransformright;
    [SerializeField] private float attackRange = 1.5f;
    [SerializeField] private LayerMask attackableLayer;
    [SerializeField] private float damageAmmount = 1f;

    [SerializeField] private float attackStamina = 0f;
    private PlayerMovement player;
    PlayerMovement movement;

    Animator animator;



    private void Start()
    {
        player = GetComponent<PlayerMovement>();
        animator = GetComponent<Animator>();
        movement = gameObject.GetComponent<PlayerMovement>();
    }



    public override void FixedUpdateNetwork()
    {
        if (attackStamina > 0f)
        {
            attackStamina -= Time.deltaTime;
        }
        if (attackStamina < 0f)
        {
            attackStamina = 0;
        }
        if (UserInput.instance.controls.Attack.AttackUp.WasPressedThisFrame() && attackStamina == 0f)
        {
            AttackUp();
        }
        if (UserInput.instance.controls.Attack.AttackDown.WasPressedThisFrame() && attackStamina == 0f)
        {
            AttackDown();
        }
        if (UserInput.instance.controls.Attack.AttackLeft.WasPressedThisFrame() && player.Net_FlipX == false && attackStamina == 0f)
        {
            animator.SetTrigger("AttackBack");
            AttackRight();
        }
        else if (UserInput.instance.controls.Attack.AttackLeft.WasPressedThisFrame() && player.Net_FlipX == true && attackStamina == 0f)
        {
            animator.SetTrigger("AttackFront");
            AttackLeft();
            
        }
        if (UserInput.instance.controls.Attack.AttackRight.WasPressedThisFrame() && player.Net_FlipX == false && attackStamina == 0f)
        {
            animator.SetTrigger("AttackFront");
            AttackRight();
        }
        else if (UserInput.instance.controls.Attack.AttackRight.WasPressedThisFrame() && player.Net_FlipX == true && attackStamina == 0f)
        {
            animator.SetTrigger("AttackBack");
            AttackLeft();
        }

    }

    #region Attacks
    private void AttackUp()
    {
        attackStamina = 0.5f;
        Debug.Log("AttackedUp");
        animator.SetTrigger("AttackUp");
        hits = Physics2D.CircleCastAll(attackTransformup.position, attackRange, transform.up, 0f, attackableLayer);
        for (int i = 0; i < hits.Length; i++)
        {
            iDamage iDamage = hits[i].collider.gameObject.GetComponent<iDamage>();
            if (iDamage != null)
            {
                iDamage.damage(damageAmmount);
            }
            
        }
    }

    private void AttackDown()
    {
        attackStamina = 0.25f;
        animator.SetTrigger("AttackDown");
        Debug.Log("AttackedDown");
        hits = Physics2D.CircleCastAll(attackTransformdown.position, attackRange, transform.up, 0f, attackableLayer);
        for (int i = 0; i < hits.Length; i++)
        {
            iDamage iDamage = hits[i].collider.gameObject.GetComponent<iDamage>();
            if (iDamage != null)
            {
                iDamage.damage(damageAmmount);
                movement.ApplyKnockup();
            }

            
            
        }
    }

    private void AttackLeft()
    {
        attackStamina = 0.5f;
        
        Debug.Log("AttackedLeft");
        hits = Physics2D.CircleCastAll(attackTransformleft.position, attackRange, transform.up, 0f, attackableLayer);
        for (int i = 0; i < hits.Length; i++)
        {
            iDamage iDamage = hits[i].collider.gameObject.GetComponent<iDamage>();
            if (iDamage != null)
            {
                iDamage.damage(damageAmmount);
            }
        }
    }

    private void AttackRight()
    {
        
        attackStamina = 0.5f;
        Debug.Log("AttackedRight");
        hits = Physics2D.CircleCastAll(attackTransformright.position, attackRange, transform.up, 0f, attackableLayer);
        for (int i = 0; i < hits.Length; i++)
        {
            iDamage iDamage = hits[i].collider.gameObject.GetComponent<iDamage>();
            if (iDamage != null)
            {
                iDamage.damage(damageAmmount);
            }
            //player player = hits[i].collider.gameObject.GetComponent<PlayerMovement>();
            //if (player != null)
            //{
            //    player.ApplyKnockfront();
            //}
        }
    }
    #endregion

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackTransformup.position, attackRange);
        Gizmos.DrawWireSphere(attackTransformdown.position, attackRange);
        Gizmos.DrawWireSphere(attackTransformleft.position, attackRange);
        Gizmos.DrawWireSphere(attackTransformright.position, attackRange);
    }







}
