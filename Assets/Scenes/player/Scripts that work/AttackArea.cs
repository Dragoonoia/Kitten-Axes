using UnityEngine;
using UnityEngine.Rendering;

public class AttackArea : MonoBehaviour
{
    enemy1 pipoco;
    PlayerMovement knockers;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "MyEnemy")
        {
            pipoco = collision.GetComponent<enemy1>();
            pipoco.Die();
            //collision.gameObject.SetActive(false);
        }

        if (collision.tag == "PlayerGaming")
        {
            Debug.Log("BateuNoPlayer");
            knockers = collision.GetComponent<PlayerMovement>();
            //knockers.ApplyKnockback();

        }
    }
}
