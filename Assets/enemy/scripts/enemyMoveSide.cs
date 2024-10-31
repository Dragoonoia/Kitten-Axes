using System.Runtime.CompilerServices;
using UnityEngine;
using Fusion;

public class enemyMoveSide : MonoBehaviour
{
    
    private Rigidbody2D rb;
    private Transform currentPoint;
    [SerializeField] private float speed;
    [SerializeField] private bool goingright;
    [SerializeField] private float walktime;

    private float bsize =0.5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        goingright = true;

        
    }

    // Update is called once per frame
    void Update()
    {
        if (goingright == true)
        {
            walktime += Time.deltaTime;
            rb.linearVelocityX = speed;
        }
        if (goingright == false)
        {
            walktime -= Time.deltaTime;
            rb.linearVelocityX = -speed;
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
