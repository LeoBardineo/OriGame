using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerControl : MonoBehaviour
{
    [Header("Física")]
    public Rigidbody CorpoRigido;
    public int speed = 0, frontalSpeed = 5, jumpForce = 0;
    private bool jumping = false;

    [Header("Pontuação")]
    public int pontos = 0, pontosParaGanhar = 0;

    [Header("UI")]
    public GameObject TelaVitoria, TelaDerrota;
    public TMP_Text TextoDeDerrota;

    private void Movement()
    {
        float inputHorizontal = Input.GetAxis("Horizontal");
        CorpoRigido.velocity = new Vector3(inputHorizontal * speed, CorpoRigido.velocity.y, frontalSpeed);
        if (!jumping && Input.GetKeyDown(KeyCode.Space))
        {
            jumping = true;
            Debug.Log(jumping);
            CorpoRigido.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
        else
        {
            jumping = false;
        }
    }

    public void Die()
    {
        TextoDeDerrota.SetText("Perdeu!\nVocê pegou " + pontos +" moedas.");
        TelaDerrota.SetActive(true);
    }

    public void Win()
    {
        if (pontos >= pontosParaGanhar)
        {
            TelaVitoria.SetActive(true);
            return;
        }
        TextoDeDerrota.SetText("Você não pegou moedas suficientes.\nVocê pegou " + pontos + " moedas.");
        TelaDerrota.SetActive(true);
    }

    public void GanhaPonto()
    {
        pontos++;
        Debug.Log("Pontos: " + pontos);
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }
}
