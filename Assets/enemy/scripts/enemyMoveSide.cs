using System.Runtime.CompilerServices;
using UnityEngine;
using Fusion;

public class enemyMoveSide : MonoBehaviour
{
    [SerializeField] private GameObject pointA;
    [SerializeField] private GameObject pointB;
    [SerializeField] private Transform PAball;
    [SerializeField] private Transform PBball;
    private Rigidbody2D rb;
    private Transform currentPoint;
    [SerializeField] private float speed;
    [SerializeField] private bool goingright;

    private float bsize =0.5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentPoint = pointB.transform;

        
    }

    // Update is called once per frame
    void Update()
    {
        if (goingright == true)
        {
            rb.linearVelocityX = speed;
        }
        if (goingright == false)
        {
            rb.linearVelocityX = -speed;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("enemywalkswitch"))
        {
            switcheroo();
        }
    }

    private void switcheroo()
    {
        if (goingright ==true)
        {
            goingright = false;
        }
        else if (goingright == false)
        {
            goingright= true;
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(PAball.position, bsize);
        Gizmos.DrawWireSphere(PBball.position, bsize);
    }
}
