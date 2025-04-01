using UnityEngine;

public class floating : MonoBehaviour
{
    public float floatHeight = 2f;
    public float floatSpeed = 1f;
    public float smoothSpeed = 0.125f;

    private Vector3 initialPosition;

    void Start()
    {
        initialPosition = transform.position;

        floatHeight = Random.Range(1f, 2f);
        floatSpeed = Random.Range(0.5f, 2f);
    }

    void Update()
    {
        float yOffset = Mathf.Sin(Time.time * floatSpeed) * floatHeight;

        Vector3 targetPosition = new Vector3(initialPosition.x, initialPosition.y + yOffset, initialPosition.z);

        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed);
    }
}
