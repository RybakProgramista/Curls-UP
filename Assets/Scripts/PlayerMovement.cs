using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private readonly PlayerController playerController;
    [SerializeField]
    private Transform spriteT;
    private Rigidbody2D playerRgb;

    [SerializeField]
    private float speedMultiplier, jumpMultiplier;

    void Start()
    {
        playerRgb = GetComponent<Rigidbody2D>();    
    }
    float jumpForce(float jumpForce)
    {
        if(jumpForce > 0)
        {
            return jumpForce;
        }
        else
        {
            return playerRgb.velocity.y;
        }
    }
    void FixedUpdate()
    {
        float speed = Input.GetAxis("Horizontal") * speedMultiplier;
        float jumpSpeed = Input.GetAxis("Jump") * jumpMultiplier;

        playerRgb.velocity = new Vector2(speed, jumpForce(jumpSpeed));
    }
}
