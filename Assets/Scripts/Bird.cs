using UnityEngine;

public class Bird : MonoBehaviour
{
    public Rigidbody2D myRigidBody;
    public float flapStrength = 10;
    public LogicScript logic;
    public bool birdIsAlive = true;
    [SerializeField] private GameObject kunaiPrefab;
    [SerializeField] private AudioSource flapSound;
    private Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        flapSound = GetComponent<AudioSource>();
    }

    void Start()
    {
           logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && birdIsAlive){
            myRigidBody.linearVelocity = Vector2.up * flapStrength;
            animator.Play("Flap",0,0f);
            flapSound.Play();
        }
        if(Input.GetKeyDown(KeyCode.E) && birdIsAlive)
        {
            Instantiate(kunaiPrefab, transform.position, Quaternion.identity);
        }

        if(transform.position.y > 17 || transform.position.y < -17)
        {
            logic.GameOver();
            birdIsAlive = false;
        }
        
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        logic.GameOver();
        birdIsAlive = false;
    }
}
