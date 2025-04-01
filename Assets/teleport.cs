using UnityEngine;

public class teleport : MonoBehaviour
{
    public Vector3 targetPosition;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.position = targetPosition;
        }
    }
}
