
using System.Runtime.CompilerServices;
using UnityEngine;

public class Target : MonoBehaviour
{
    public Rigidbody targetRb;
    public GameManager gameManager;
    public ParticleSystem explosionParticle;
    private float minSpeed = 12;
    private float maxSpeed = 16;
    private float maxTorque = 10;
    private float xRange = 4;
    private float ySpawnPos = -2;
    public int pointValue;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        targetRb = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        targetRb.AddForce(RandomForce(), ForceMode.Impulse);
        targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
        transform.position = RandomSpawnPos();
        gameManager.livesText.text = "Lives:" + gameManager.lives;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnMouseDown()
    {
        Destroy(gameObject);
        Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
        gameManager.UpdateScore(pointValue);
    }
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        if (!gameObject.CompareTag("Bad"))
            gameManager.lives -= 1;
        gameManager.livesText.text = "Lives:" + gameManager.lives;
        if (gameManager.lives <= 0)
        {
            gameManager.GameOver();
            gameManager.livesText.text = "Lives:" + 0;
        }

    }
    public void DestroyTarget()
    {
        if (gameManager.isGameActive)
        {
            Destroy(gameObject);
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
            gameManager.UpdateScore(pointValue);
        }
    }
    UnityEngine.Vector3 RandomForce()
    {
        return UnityEngine.Vector3.up * Random.Range(minSpeed, maxSpeed);
    }
    float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }
    UnityEngine.Vector3 RandomSpawnPos()
    {
        return new UnityEngine.Vector3(Random.Range(-xRange, xRange), ySpawnPos);
    }
}
