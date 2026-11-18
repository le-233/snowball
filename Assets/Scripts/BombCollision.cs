using UnityEngine;

public class BombCollision : MonoBehaviour
{
    public ParticleSystem explosionParticle;
    public float moveSpeed = 2f;

public float leftBoundary = -5f;
public float rightBoundary = 5f;

private int moveDirection;
private bool exploded = false;
    void Start()
    {
        moveDirection = Random.value < 0.5f ? -1 : 1;
        
    }
    void Update()
    {
        if (exploded) return;
        transform.position += Vector3.right * moveDirection * moveSpeed * Time.deltaTime;
        if (transform.position.x >= rightBoundary)
        {Vector3 position = transform.position;
        position.x = rightBoundary;
        transform.position = position;
        moveDirection = -1;
        }
        
        if (transform.position.x <= leftBoundary)
        {
            Vector3 position = transform.position;
            position.x = leftBoundary;
            transform.position = position;
            moveDirection = 1;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Bomb Hit!");
            explosionParticle.Play();
            GetComponent<Collider>().enabled = false;
            GetComponent<Renderer>().enabled = false;
        }
    }
}