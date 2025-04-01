using UnityEngine;

public class skip : MonoBehaviour
{
    public Transform playerTransform;
    public Vector3[] levelPositions;
    public KeyCode[] levelKeys;

    private void Update()
    {
        for (int i = 0; i < levelKeys.Length; i++)
        {
            if (Input.GetKeyDown(levelKeys[i]))
            {
                if (i < levelPositions.Length)
                {
                    TeleportToTargetPosition(levelPositions[i]);
                }
                break;
            }
        }
    }

    private void TeleportToTargetPosition(Vector3 targetPosition)
    {
        playerTransform.position = targetPosition;
    }
}
