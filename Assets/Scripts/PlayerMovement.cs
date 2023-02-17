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
    private float speedMultiplier, jumpMultiplier, rotateMultiplier;
    [SerializeField]
    private bool isGrounded, canMove;

    void Start()
    {
        playerRgb = GetComponent<Rigidbody2D>();
        isGrounded = true;
    }
    public bool getCanMove()
    {
        return canMove;
    }
    public void setCanMove(bool canMove)
    {
        this.canMove = canMove;
    }
    float jumping(float jumpForce)
    {
        if(jumpForce > 0 && isGrounded)
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
        if (canMove)
        {
            float speed = Input.GetAxis("Horizontal") * speedMultiplier;
            float jumpForce = Input.GetAxis("Jump") * jumpMultiplier;

            playerRgb.velocity = new Vector2(speed, jumping(jumpForce));
            spriteT.Rotate(new Vector3(0, 0, 1), speed * Time.deltaTime * rotateMultiplier);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGrounded = true;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }
}
