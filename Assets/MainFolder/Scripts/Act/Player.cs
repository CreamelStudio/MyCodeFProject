using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Update = UnityEngine.PlayerLoop.Update;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float playerMoveSpeed;
    [SerializeField]
    private float playerJumpForce;

    private Rigidbody playerRb;

    private void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        
    }

    private void Move()
    {
        float v = Input.GetAxisRaw("Vertical");
        float h = Input.GetAxisRaw("Horizontal");

        playerRb.velocity = new Vector3(h * Time.deltaTime * playerMoveSpeed, 0, v * Time.deltaTime * playerMoveSpeed).normalized;
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerRb.AddForce(Vector3.up * playerJumpForce, ForceMode.Impulse);
        }
    }
}
