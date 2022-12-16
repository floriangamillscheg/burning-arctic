using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreen : MonoBehaviour
{
    public void Restart()
    {
        SceneManager.LoadScene("introHare");
    }

    public void Main()
    {
        SceneManager.LoadScene("StartScreen");
    }
}
