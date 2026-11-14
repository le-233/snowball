using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    private bool collected = false;
    private void OnTriggerEnter(Collider other)
    {
        if (collected) return;
        if (other.CompareTag("Player"))
        {
            collected = true;
            Debug.Log("Snowflake Collected!");
            other.transform.localScale *= 1.4f;
            GetComponent<Collider>().enabled = false;

            Animator animator = GetComponent<Animator>();
            if (animator != null)
            {
                animator.enabled = false;
            }

            Vector3 direction = (transform.position - other.transform.position).normalized;
            if (direction == Vector3.zero)
            {
                direction = Vector3.up;
            }
            float radius = other.bounds.extents.x;
            transform.position = other.transform.position + direction * (radius * 1.2f);
            transform.rotation = Quaternion.LookRotation(direction, Vector3.up) * Quaternion.Euler(90f, 0f, 0f);
            transform.localScale *= 0.7f;
            transform.SetParent(other.transform, true);
        }
    }
}
