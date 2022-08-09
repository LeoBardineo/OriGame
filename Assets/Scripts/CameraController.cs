using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float XOffset,  YOffset,  ZOffset;
    public GameObject Jogador;

    // Update is called once per frame
    void Update()
    {
        float x = Jogador.transform.position.x + XOffset;
        float y = Jogador.transform.position.y + YOffset;
        // float y = transform.position.y + YOffset;
        float z = Jogador.transform.position.z + ZOffset;
        transform.position = new Vector3(x, y, z);
    }
}
