using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject TelaVitoria, TelaDerrota, TelaPause;

    void Start()
    {
        Time.timeScale = 1;
    }

    public void Win()
    {
        TelaVitoria.SetActive(true);
        Time.timeScale = 0;
    }

    public void Defeat()
    {
        TelaDerrota.SetActive(true);
        Time.timeScale = 0;
    }

    public void Pause(bool isPaused)
    {
        TelaPause.SetActive(isPaused);
        if (isPaused) Time.timeScale = 0;
        else Time.timeScale = 1;
    }

    public void TryAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
