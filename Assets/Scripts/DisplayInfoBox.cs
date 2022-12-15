using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]

public class DisplayInfoBox : MonoBehaviour {

    protected void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("InfoBox")) {
            Canvas infobox = other.gameObject.GetComponentInChildren(typeof(Canvas), true) as Canvas;
            infobox.gameObject.SetActive(true);
        }
    }

    protected void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("InfoBox")) {
            Canvas infobox = other.gameObject.GetComponentInChildren(typeof(Canvas)) as Canvas;
            infobox.gameObject.SetActive(false);

            // TODO: Discuss if this is this the right place for this
            GameObject door = GameObject.Find("Door");
            if (door != null)
            {
                door.GetComponent<Door>().InfoBoxFound(infobox);
            }
        }
    }
}
