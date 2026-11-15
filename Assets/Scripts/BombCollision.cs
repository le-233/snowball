using UnityEngine;

public class BombCollision : MonoBehaviour
{
    public ParticleSystem explosionParticle;

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