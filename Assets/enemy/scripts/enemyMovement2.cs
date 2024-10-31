using UnityEngine;

public class enemyMovement2 : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool goingRight;
    [SerializeField] private float walkcool = 1f;
    [SerializeField] private float speed = 5f;
    void Start()
    {
        goingRight = true;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
       if (goingRight)
        {
            rb.linearVelocityX = speed;
            walkcool += Time.deltaTime;
        }
        else
        {
            rb.linearVelocityX = -speed;
            walkcool -= Time.deltaTime;
        }

        if (walkcool < 0 && !goingRight)
        {
            goingRight = true;
        }
        if (walkcool > 2 && goingRight)
        {
            goingRight = false;
        }

        
    }
}
