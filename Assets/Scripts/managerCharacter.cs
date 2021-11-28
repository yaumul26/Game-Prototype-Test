using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class managerCharacter : MonoBehaviour
{
    #region Singleton
    public static managerCharacter instance;
    public bool runActive;
    public GameObject butRun;
    #endregion

    public GameObject[] cam;
    private Vector3 velocity;
    private Vector3 playerMovementInput;
    private Vector3 playerMouseInput;
    private Vector3 moveVector;
    private CharacterController controller;
    private Animator anim;
    private float xRot;
    private float yRot;

    [Space]
    [SerializeField] private float speed;
    [SerializeField] private float walkSpeed;
    [SerializeField] private float runSpeed;
    [SerializeField] private float rotateSpeed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float sensitivity;
    [SerializeField] private float gravity =-9.81f;
    [SerializeField] managerJoystick joystickMovement;
    [SerializeField] managerJoystick joystickRotateCamera;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        playerMovementInput = new Vector3(joystickMovement.inputHorizontal(), 0, joystickMovement.inputVertical());
        playerMouseInput = new Vector2(joystickRotateCamera.inputMouseX(),joystickRotateCamera.inputMouseY());

        MovePlayer();
        MovePlayerCamera();
    }

    void MovePlayer()
    {
        moveVector = transform.TransformDirection(playerMovementInput);

        if (controller.isGrounded)
        {
            velocity.y = -1f;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                velocity.y = jumpForce;
            }

            if (moveVector != Vector3.zero && !Input.GetKeyDown(KeyCode.LeftShift))
            {
                Walk();
            }
            else if (moveVector != Vector3.zero && Input.GetKeyDown(KeyCode.LeftShift))
            {
                Run();
            }
            else if(moveVector == Vector3.zero)
            {
                Idle();
            }
        }
        else
        {
            velocity.y -= gravity * -2f * Time.deltaTime;
        }
        controller.Move(moveVector * speed * Time.deltaTime);
        controller.Move(velocity * Time.deltaTime);
    }

    void MovePlayerCamera()
    {
        float mouseSensitivity = 3;
        float mouseX = joystickRotateCamera.inputHorizontal();
        float mouseY = joystickRotateCamera.inputVertical();

        xRot -= mouseY;
        xRot = Mathf.Clamp(xRot, -17f, 24);

        cam[1].transform.localRotation = Quaternion.Euler(xRot, -150f, 0);
        //transform.localRotation = Quaternion.Euler(xRot, -150f, 0);
        transform.Rotate(Vector3.up * mouseX);
    }

    #region kumpulan animasi
    void Walk()
    {
        speed = walkSpeed;
        anim.SetFloat("Speed_f", 0.5f, 0.1f, Time.deltaTime);
    }
    public void Run()
    {
        speed = runSpeed;
        anim.SetFloat("Speed_f", 1, 0.1f, Time.deltaTime);
    }
    void Idle()
    {
        anim.SetFloat("Speed_f", 0, 0.1f, Time.deltaTime);
    }

    void Shooter(int value)
    {
        anim.SetInteger("WeaponType_int", value);
    }

    public void Dead()
    {
        anim.SetBool("Death_b", true);
    }

    void Reload(bool status)
    {
        anim.SetBool("Reload_b", status);
    }
    #endregion

    public void startShoot()
    {
        Shooter(1);
    }

    public void endShoot()
    {
        Shooter(0);
    }

    public void startReload()
    {
        Reload(true);
    }

    public void endReload()
    {
        Reload(false);
    }

}
