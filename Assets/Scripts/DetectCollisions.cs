using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Snowflake Collected!");
            other.transform.localScale *= 1.4f;
        }
    }
}
