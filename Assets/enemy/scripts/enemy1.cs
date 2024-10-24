using UnityEngine;

public class enemy1 : MonoBehaviour, iDamage
{

    [SerializeField] private float maxHealth = 1f;
    private float CurrentHealth;

    public void damage(float damageAmmount)
    {
        CurrentHealth -= damageAmmount;
        if (CurrentHealth <= 0)
        {
            Die();
        }
    }

    private void Start()
    {
        CurrentHealth = maxHealth;
    }
    private void Die()
        {
            Destroy(gameObject);
        }
}

