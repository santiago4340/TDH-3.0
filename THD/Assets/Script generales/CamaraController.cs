using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float sensitivity = 100f;
    private bool canMove = true;

    void Update()
    {
        if (canMove)
        {
            float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

            transform.Rotate(Vector3.up * mouseX);
            transform.Rotate(Vector3.right * -mouseY);
        }
    }

    public void EnableCameraMovement(bool enable)
    {
        canMove = enable;
    }
}
