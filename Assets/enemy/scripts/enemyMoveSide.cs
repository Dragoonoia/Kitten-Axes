using System.Runtime.CompilerServices;
using UnityEngine;
using Fusion;

public class enemyMoveSide : NetworkBehaviour
{
    
    private Rigidbody2D rb;
    private Transform currentPoint;
    [SerializeField] private float speed;
    [SerializeField] private bool goingright;
    [SerializeField] private float walktime;

    private SpriteRenderer sprite;

    private float bsize =0.5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        goingright = true;

        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (goingright == true)
        {
            walktime += Time.deltaTime;
            rb.linearVelocityX = speed;
            sprite.flipX = true;

        }
        if (goingright == false)
        {
            walktime -= Time.deltaTime;
            rb.linearVelocityX = -speed;
            sprite.flipX = false;
        }
            if (goingright == true && walktime >= 1)
            {
                goingright = false;
            }
            else if (goingright == false && walktime <= 0)
            {
                goingright = true;
            }
    }
    
    
}
