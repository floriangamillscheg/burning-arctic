using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayInfoBox : MonoBehaviour
{
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
        }
    }
}
