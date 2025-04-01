using UnityEngine;

public class up : MonoBehaviour
{
    public Vector3 targetPosition;
    public float moveSpeed = 5f;

    private Vector3 initialPosition;
    private bool isMoving = false;

    private void Start()
    {
        initialPosition = transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isMoving = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isMoving = false;
            StartCoroutine(MoveToInitialPosition());
        }
    }

    private System.Collections.IEnumerator MoveToInitialPosition()
    {
        while (transform.position != initialPosition)
        {
            transform.position = Vector3.MoveTowards(transform.position, initialPosition, moveSpeed * Time.deltaTime);
            yield return null;
        }
    }

    private void Update()
    {
        if (isMoving)
        {
            MoveToTargetPosition();
        }
    }

    private void MoveToTargetPosition()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
    }
}
