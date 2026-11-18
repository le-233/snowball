using UnityEngine;
public class star : MonoBehaviour
{
    public float rotationSpeed = 90f;
    public int points = 1;
    private bool collected = false;

    void Update()
    {
        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") ||other.transform.root.CompareTag("Player"))
        {
            collected = true;
            ScoreManager.Instance.AddScore(points);
            Destroy(gameObject);
        }
    }
}
