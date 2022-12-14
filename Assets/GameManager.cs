using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager _Instance;
    public GameObject GameOverUI;
    public GameObject player;

    // Start is called before the first frame update
    void Awake()
    {
        if (_Instance == null)
            _Instance = this;
    }
     

    public void setGameOver()
    {
        player.SetActive(false);
        GameOverUI.SetActive(true);

    }
    public void LevelExit()
    {
        SceneManager.LoadScene("StartScreen");

    }
}
