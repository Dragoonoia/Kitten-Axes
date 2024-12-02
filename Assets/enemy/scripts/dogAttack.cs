using UnityEngine;
using Fusion;
using System;

public class dogAttack : NetworkBehaviour
{
    [SerializeField] dogAttack2 Dog;
    bool canAttack;

    void Start()
    {
        
    }

    // Update is called once per frame
    public override void FixedUpdateNetwork()
    {
       

    }

    private void OnCollisionEnter2D(UnityEngine.Collision2D collision)
    {
        if (collision.gameObject.tag == "PlayerGaming")
        {
          
        }
    }
}
