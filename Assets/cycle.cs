using UnityEngine;

public class cycle : MonoBehaviour
{
    public Vector3 positionA;
    public Vector3 positionB;
    public float swapFrequency = 0.8f;

    private void Start()
    {
        InvokeRepeating("SwapPosition", 0f, 1f / swapFrequency);
    }

    private void SwapPosition()
    {
        if (transform.position == positionA)
        {
            transform.position = positionB;
        }
        else
        {
            transform.position = positionA;
        }
    }
}
