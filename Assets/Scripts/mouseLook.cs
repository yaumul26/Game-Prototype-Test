using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseLook : MonoBehaviour
{
    public float mouseSensitivity = 100;
    public Transform playerBody;
    float xRotation = 0;
    public managerJoystick joystick;
    // Start is called before the first frame update
    void Start()
    {
        float mouseX = joystick.inputMouseX() * mouseSensitivity * Time.deltaTime;
        float mouseY = joystick.inputMouseY() * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -17f, 42);

        transform.localRotation = Quaternion.Euler(xRotation, -150f, 0);
        playerBody.Rotate(Vector3.up * mouseX);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
