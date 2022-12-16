using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndHareLevel : MonoBehaviour
{
    protected void OnTriggerExit2D(Collider2D other)
    {
        SceneManager.LoadScene("EndScene");
    }
}