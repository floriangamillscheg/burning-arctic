using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayInfoBox : MonoBehaviour
{
    protected void OnTriggerEnter2D(Collider2D other) {
        Debug.unityLogger.Log("collision enter");
        if (other.CompareTag("InfoBox")) {
            Canvas infobox = other.gameObject.GetComponentInChildren(typeof(Canvas), true) as Canvas;
            infobox.gameObject.SetActive(true); 
            Debug.unityLogger.Log("collision enter tag");
        }
    }

    protected void OnTriggerExit2D(Collider2D other) {
        Debug.unityLogger.Log("collision exit ");
        if (other.CompareTag("InfoBox")) {
            Canvas infobox = other.gameObject.GetComponentInChildren(typeof(Canvas)) as Canvas;
            infobox.gameObject.SetActive(false); 
            Debug.unityLogger.Log("collision exit tag");
        }
    }
}
