using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public void ReloadScreen()
    {
        Debug.Log("oi");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
