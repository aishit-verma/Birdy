using UnityEngine;

public class OpenPipe : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Kunai"))
        {
            animator.SetTrigger("Open");
        }
    }
}