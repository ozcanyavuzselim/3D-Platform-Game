using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Karakter hareketi kontrol eden sınıf
public class PlayerMovement : MonoBehaviour
{
    //Kamera denetimi
    public float mauseSensitivity;
    private float xRotation = 0f;
    //Hareket
    private CharacterController controller; 
    public float speed = 1f;

    //Zıplama ve Yerçekimi
    private Vector3 velocity;
    private float gravity = -9.81f;
    private bool isGround;

    public Transform groundChacker;
    public float groundCrackerRadius;
    public LayerMask obstacleLatyer;

    public float jumpHeight = 0.1f;
    public float gravityDivide = 100f;
    public float jumpSpeed= 100f;

    private float atimer;
    private void Awake()
    {
        controller = GetComponent<CharacterController>();

        //imleç
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void Update()
    {
        //Karakterin zeminde olup olmadığını kontrol et
        isGround = Physics.CheckSphere(groundChacker.position, groundCrackerRadius, obstacleLatyer);

        //Hareket
        Vector3 moveInputs = Input.GetAxis("Horizontal") * transform.right + Input.GetAxis("Vertical") * transform.forward;
        Vector3 moveVelocity = moveInputs * Time.deltaTime * speed;

        controller.Move(moveVelocity);

        //Kamera denetimi
        transform.Rotate(0, Input.GetAxis("Mouse X") * Time.deltaTime * mauseSensitivity *100f, 0);
        xRotation -= Input.GetAxis("Mouse Y") * Time.deltaTime * mauseSensitivity * 100f;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        Camera.main.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);



        //Zıplama ve Yerçekimi

        if (!isGround)
        {
            velocity.y += gravity * Time.deltaTime / gravityDivide;
            speed = jumpSpeed;
            //atimer += Time.deltaTime /3;
            //speed = Mathf.Lerp(10, jumpSpeed, atimer);
        }
        else
        {
            velocity.y = -0.05f;
            speed = 10f;
           // atimer = 0f;
        }

        if(Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity / gravityDivide);
        }

        controller.Move(velocity);
    }
}
