using UnityEngine;

public class SnowballController : MonoBehaviour
{
    public float forwardSpeed = 5f;
    public float horizontalSpeed = 4f;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime);
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * horizontalSpeed * Time.deltaTime);
    }
}
