using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox : MonoBehaviour
{
    public PlayerControl Jogador;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Obstaculo"))
        {
            Jogador.Die();
        }
        else if (other.CompareTag("Final"))
        {
            Jogador.Win();
        }
        else if (other.CompareTag("Moeda"))
        {
            Jogador.GanhaPonto();
            other.gameObject.SetActive(false);
        }
    }
}
