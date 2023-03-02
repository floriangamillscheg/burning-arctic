using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    

    public void Restart()
    {
        Debug.Log("Pressed restart");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void BackToMenu()
    {
        Debug.Log("Pressed Menu");
        SceneManager.LoadScene("StartScreen");
    }
}

