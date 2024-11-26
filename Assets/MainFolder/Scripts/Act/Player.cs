using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
    [SerializeField]
    private float playerMoveSpeed;
    [SerializeField]
    private float playerJumpForce;

    [SerializeField]
    private float playerRunSpeed;

    private Rigidbody playerRb;

    [SerializeField]
    private bool isCanMove;


    [Header("Rotate")]
    public float mouseSpeed;
    float yRotation;
    float xRotation;
    UnityEngine.Camera cam;

    public GameObject transition;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        cam = UnityEngine.Camera.main;
        playerRb = GetComponent<Rigidbody>();

        playerRb.freezeRotation = true;
        StartCoroutine(Co_TransitionOff());
    }

    private void Update()
    {
        if (isCanMove || SceneManager.GetActiveScene().name == "Act1-1")
        {
            CamMove();
        }
    }

    private void FixedUpdate()
    {
        if (isCanMove)
        {
            Move();
        }
    }

    public void SwitchCanMove()
    {
        isCanMove = !isCanMove;
    }

    private void Move()
    {
        float v = Input.GetAxisRaw("Vertical");
        float h = Input.GetAxisRaw("Horizontal");
        if (Input.GetKey(KeyCode.LeftShift))
        {
            Vector3 moveDir = (transform.forward * v + transform.right * h).normalized * playerRunSpeed;
            playerRb.velocity = moveDir;
        }
        else
        {
            Vector3 moveDir = (transform.forward * v + transform.right * h).normalized * playerMoveSpeed;
            playerRb.velocity = moveDir;
        }
        
    }

    private void CamMove()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * mouseSpeed * Time.deltaTime;
        float mouseY = Input.GetAxisRaw("Mouse Y") * mouseSpeed * Time.deltaTime;

        yRotation += mouseX;
        xRotation -= mouseY;

        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        cam.transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        transform.rotation = Quaternion.Euler(0, yRotation, 0); 
    }

    IEnumerator Co_TransitionOff()
    {
        yield return new WaitForSeconds(9);
        transition.SetActive(false);
    }
}
