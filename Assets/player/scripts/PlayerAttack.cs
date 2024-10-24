using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private RaycastHit2D[] hits;
    [SerializeField] private Transform attackTransformup;
    [SerializeField] private Transform attackTransformdown;
    [SerializeField] private Transform attackTransformleft;
    [SerializeField] private Transform attackTransformright;
    [SerializeField] private float attackRange = 1.5f;
    [SerializeField] private LayerMask attackableLayer;
    [SerializeField] private float damageAmmount = 1f;


    private void Update()
    {
        if (UserInput.instance.controls.Attack.AttackUp.WasPressedThisFrame())
        {
            AttackUp();
        }
        if (UserInput.instance.controls.Attack.AttackDown.WasPressedThisFrame())
        {
            AttackDown();
        }
        if (UserInput.instance.controls.Attack.AttackLeft.WasPressedThisFrame())
        {
            AttackLeft();
        }
        if (UserInput.instance.controls.Attack.AttackRight.WasPressedThisFrame())
        {
            AttackRight();
        }
    }

    #region Attacks
    private void AttackUp()
    {
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
        hits = Physics2D.CircleCastAll(attackTransformdown.position, attackRange, transform.up, 0f, attackableLayer);
        for (int i = 0; i < hits.Length; i++)
        {
            iDamage iDamage = hits[i].collider.gameObject.GetComponent<iDamage>();
            if (iDamage != null)
            {
                iDamage.damage(damageAmmount);
            }
        }
    }

    private void AttackLeft()
    {
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
        hits = Physics2D.CircleCastAll(attackTransformright.position, attackRange, transform.up, 0f, attackableLayer);
        for (int i = 0; i < hits.Length; i++)
        {
            iDamage iDamage = hits[i].collider.gameObject.GetComponent<iDamage>();
            if (iDamage != null)
            {
                iDamage.damage(damageAmmount);
            }
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
