using UnityEngine;

public class Kunai : MonoBehaviour
{
    private Rigidbody2D rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    public void Update()
    {
        float speed = 250f;
        float deadZone = 40f;
        rb.AddForce(transform.right * speed * Time.deltaTime, ForceMode2D.Impulse);
        if (transform.position.x > deadZone)
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Target"))
        {
            // Debug.Log("Hit Target");
        }
    }
}