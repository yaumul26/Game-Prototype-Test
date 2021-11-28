using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mmorpgCamera : MonoBehaviour
{
    [SerializeField] private float chrSpeed;
    [SerializeField] private float rotateSpeed;
    [SerializeField] private managerJoystick joystick;
    private CharacterController controller;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(-joystick.inputMouseY(), joystick.inputMouseX() * rotateSpeed, 0);
        //Vector3 forwardDIR = transform.TransformDirection(Vector3.forward);
        //float curSpeed = chrSpeed * joystick.inputVertical();
        //controller.SimpleMove(forwardDIR * curSpeed);
    }
}
