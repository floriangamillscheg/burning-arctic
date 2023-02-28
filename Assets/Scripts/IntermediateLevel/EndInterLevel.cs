using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndInterLevel : MonoBehaviour {
    protected void OnTriggerEnter2D(Collider2D other) {
        UnityEngine.SceneManagement.SceneManager.LoadScene("EndScene");
    }
}
