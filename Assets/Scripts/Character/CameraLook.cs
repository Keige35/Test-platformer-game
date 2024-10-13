using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;

public class CameraLook : MonoBehaviour
{
    [SerializeField] private GameObject cameraFollowTarget;
    [SerializeField] private float mouseSpeed = 5f;
    private float mouseX;
    private float mouseY;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
        mouseX += Input.GetAxis("Mouse X") * mouseSpeed * Time.deltaTime;
        mouseY += -Input.GetAxis("Mouse Y") * mouseSpeed * Time.deltaTime;
        Quaternion rotation = Quaternion.Euler(mouseY, mouseX, 0);
        cameraFollowTarget.transform.rotation = rotation;
    }
}
