using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{

    private const float YMin = 0.0f;
    private const float YMax = 30.0f;

    public Transform lookAt;

    public Transform Player;

    public float distance = 10.0f;
    private float currentX = 0.0f;
    private float currentY = 0.0f;
    public float sensivityY = 6.0f;
    public float sensivityX = 6.0f;

    void Start()
    {
            Cursor.lockState = CursorLockMode.Locked; 
    }

    void LateUpdate()
    {

        currentX += Input.GetAxis("Mouse X") * sensivityX * Time.deltaTime;
        currentY -= Input.GetAxis("Mouse Y")  * sensivityY * Time.deltaTime;

        currentY = Mathf.Clamp(currentY, YMin, YMax);

        Vector3 Direction = new Vector3(0, 0, -distance);
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
        transform.position = lookAt.position + rotation * Direction;

        transform.LookAt(lookAt.position);

    }
}