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
        Debug.Log("tester");
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
    public void Die()
        {
        Object.RequestStateAuthority();
        Object.RequestStateAuthority();
        Debug.Log("BixoDied");
        Morri = true;
        Runner.Despawn(Object);
    }

    public override void FixedUpdateNetwork()
    {
        if (!Spawnou)
        {
            return;
        }
        if (Morri)
        {

                Runner.Despawn(Object);
        }

       
    }
}

