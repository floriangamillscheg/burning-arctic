using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;
public class StartScreen : MonoBehaviour
{
    // Start is called before the first frame update

    public void StartLevel()
    {
        SceneManager.LoadScene("Level1");
    }
}
