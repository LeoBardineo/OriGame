using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    private AudioSource SourceSomPulo, SourceSomTransformacao;
    public AudioClip SomPulo, SomTransformacao;

    public void Play(string som)
    {
        Debug.Log("???");
        switch (som)
        {
            case "pulo":
                Debug.Log("deveria ir");
                SourceSomPulo.PlayOneShot(SomPulo);
                break;
            case "transformacao":
                SourceSomTransformacao.PlayOneShot(SomTransformacao);
                break;
        }
    }

    // Start is called before the first frame update
    void Awake()
    {
        SourceSomPulo = gameObject.AddComponent<AudioSource>();
        SourceSomTransformacao = gameObject.AddComponent<AudioSource>();
    }
}
