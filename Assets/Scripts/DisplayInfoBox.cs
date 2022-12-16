using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]

public class DisplayInfoBox : MonoBehaviour {

    protected void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("InfoBox")) {
            Canvas[] infoboxes = other.gameObject.GetComponentsInChildren<Canvas>(true);
            if(infoboxes.Length > 1)
            {
                foreach (Canvas canvas in infoboxes)
                {
                    if (canvas.CompareTag("InfoAlert"))
                        canvas.gameObject.SetActive(false);
                    else
                    {
                        canvas.gameObject.SetActive(true);

                    }
                }
            }
            else
                infoboxes[0].gameObject.SetActive(true); 
        }
    }

    protected void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("InfoBox")) {
            Canvas[] infoboxes = other.gameObject.GetComponentsInChildren<Canvas>(true);
            if (infoboxes.Length > 1)
            {
                foreach (Canvas canvas in infoboxes)
                    if (canvas.CompareTag("InfoAlert"))
                        canvas.gameObject.SetActive(true);
                    else
                        canvas.gameObject.SetActive(false);
            }
            else
                infoboxes[0].gameObject.SetActive(false);

            // TODO: Discuss if this is this the right place for this
            GameObject door = GameObject.Find("Door");
            if (door != null)
            {
                door.GetComponent<Door>().InfoBoxFound(other.gameObject.GetInstanceID());
            }
        }
    }
}
