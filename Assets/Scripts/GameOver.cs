using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    

    public void Restart()
    {
        Debug.Log("Pressed restart");
        SceneManager.LoadScene("Intro_PolarBear");
    }

    public void BackToMenu()
    {
        Debug.Log("Pressed Menu");
        SceneManager.LoadScene("StartScreen");
    }
}

