using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Física")]
    public Rigidbody playerRB;
    // public GameObject groundObject;
    public int speed = 0, jumpForce = 0, maxJumps = 1;
    public float gravityScale = 5f;
    private int jumpCounter = 0;
    public bool grounded = false;
    private void Movement()
    {
        playerRB.velocity = new Vector3(speed, playerRB.velocity.y, playerRB.velocity.z);
        if ((grounded || jumpCounter < maxJumps) && Input.GetKeyDown(KeyCode.Space))
        {
            jumpCounter++;
            Vector3 upForce = Vector3.up * jumpForce;
            Debug.Log(upForce);
            playerRB.AddForce(upForce, ForceMode.Impulse);
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground")) { grounded = true; jumpCounter = 0; }
    }

    public void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground")) { grounded = false; }
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }
}
