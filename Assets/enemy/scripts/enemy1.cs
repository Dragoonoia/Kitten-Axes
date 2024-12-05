using UnityEngine;
using Fusion;
using Unity.VisualScripting;

public class enemy1 : NetworkBehaviour, iDamage
{

    [SerializeField] private float maxHealth = 1f;
    [Networked] public float CurrentHealth {  get; set; }
    float damageA;
    //public float CurrentHealth;

    public bool Morri;

    private bool Spawnou;

    public void damage(float damageAmmount)
    {
        Object.RequestStateAuthority();
        Object.RequestStateAuthority();
        Morri = true;
        damageA = damageAmmount;
        
    }

    void Awake()
    {
        
    }
    public override void Spawned()
    {
        CurrentHealth = maxHealth;
        Spawnou = true;
    }
    private void Die()
        {
        Debug.Log("abacate");
        Runner.Despawn(Object);
        }

    public override void FixedUpdateNetwork()
    {
        if (!Spawnou)
        {
            return;
        }
        if (Morri && HasStateAuthority)
        {
            CurrentHealth -= damageA;

            if (CurrentHealth <= 0)
            {
                Die();
            }
        }

       
    }
}

