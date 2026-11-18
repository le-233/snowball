using UnityEngine;

public class star : MonoBehaviour
{
    public float rotationSpeed = 90f;
    public int points = 1;
    public static int totalScore = 0;
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
            totalScore += points;
            Debug.Log("Score: " + totalScore);
            Destroy(gameObject);
        }
    }
}
