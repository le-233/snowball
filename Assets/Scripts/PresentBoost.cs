using UnityEngine;

public class PresentBoost : MonoBehaviour
{
    private bool collected = false;

    void OnTriggerEnter(Collider other)
    {
        SnowballController snowball = other.GetComponentInParent<SnowballController>();
        if (snowball != null)
        {
            collected = true;
            snowball.SpeedUp();
            ScoreManager.Instance.AddScore(5);
            Destroy(gameObject);
        }
    }
}
