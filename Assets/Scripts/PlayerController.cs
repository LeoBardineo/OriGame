using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Física")]
    public Rigidbody playerRB;
    // public GameObject groundObject;
    public int horizontalSpeed = 5, aviaoSpeed = 10, jumpForce = 0, maxJumps = 1;
    public float gravityScale = 5f;
    private int jumpCounter = 0;
    public bool grounded = false;

    public bool isAviao = false, transformando = false, isPaused = false;
    private Animator animator;
    public UIManager UIManager;
    public AudioManager AudioManagerScript;

    private IEnumerator Metamorfose()
    {
        if (!transformando)
        {
            transformando = true;
            isAviao = !isAviao;
            animator.SetBool("transformando", true);            
            animator.SetBool("isAviao", isAviao);
            AudioManagerScript.Play("transformacao");
            float animationLength = animator.GetCurrentAnimatorStateInfo(0).length;
            yield return new WaitForSecondsRealtime(animationLength);
            transformando = false;
            animator.SetBool("transformando", false);
        }
    }
    private void Movement()
    {
        if (!transformando)
        {
            if (isAviao)
            {
                playerRB.velocity = new Vector3(aviaoSpeed, playerRB.velocity.y, playerRB.velocity.z);
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    Vector3 upForce = Vector3.up * jumpForce;
                    playerRB.AddForce(upForce, ForceMode.Impulse);
                    AudioManagerScript.Play("pulo");
                }
                animator.SetFloat("verticalVelocity", playerRB.velocity.y);
            }
            else
            {
                playerRB.velocity = new Vector3(horizontalSpeed, playerRB.velocity.y, playerRB.velocity.z);
                if ((grounded || jumpCounter < maxJumps) && Input.GetKeyDown(KeyCode.Space))
                {
                    Vector3 upForce = Vector3.up * jumpForce;
                    playerRB.AddForce(upForce, ForceMode.Impulse);
                    jumpCounter++;
                }
            }
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground")) { grounded = true; jumpCounter = 0; }
        else if (collision.gameObject.CompareTag("Fim")) { UIManager.Win(); }
        else if (collision.gameObject.CompareTag("Obstaculo")) { UIManager.Defeat(); }
        else if (collision.gameObject.CompareTag("ViraAviao")) { StartCoroutine(Metamorfose()); }
    }

    public void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground")) { grounded = false; }
    }

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Q))
        //{
        //    StartCoroutine(Metamorfose());
        //}

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
            UIManager.Pause(isPaused);
        }

        Movement();
    }
}
