using UnityEngine;
using Fusion;
using Unity.VisualScripting;

public class enemy1 : NetworkBehaviour, iDamage
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
        Runner.Despawn(Object);
        }
}

