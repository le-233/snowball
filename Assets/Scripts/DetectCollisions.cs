using UnityEngine;
public class DetectCollisions : MonoBehaviour
{
    private bool collected = false;
    private Vector3 initialWorldScale;
    private Transform snowball;
    private void Start()
    {
        initialWorldScale = transform.lossyScale;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (collected) return;
        if (other.CompareTag("Player"))
        {
            collected = true;
            snowball = other.transform;
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
            transform.SetParent(other.transform, true);
            
        }
    }
    private void LateUpdate()
    {
        if (collected)
        {
            transform.localScale = initialWorldScale / snowball.lossyScale.x;
        }
    }
}
