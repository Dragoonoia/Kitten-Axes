using UnityEngine;

public class MapAnimation : MonoBehaviour
{
    private Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    public void OpenMap()
    {
        animator.SetTrigger("Open");
    }
    public void KeepMap()
    {
        animator.SetBool("Aberto", true);
    }
    public void CloseMap()
    {
        animator.SetTrigger("Close");
        animator.SetBool("Aberto", false);
    }
}
