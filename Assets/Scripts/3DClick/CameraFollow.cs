using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform cattoPosition;
    public Vector3 cameraOffSet;

    private void LateUpdate()
    {
        gameObject.transform.position = cattoPosition.transform.position + cameraOffSet;
    }
}
